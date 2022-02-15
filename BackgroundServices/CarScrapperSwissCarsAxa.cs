﻿using CarTradeCenter.Contracts;
using CarTradeCenter.Data.Models;
using CarTradeCenter.WebScrap;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarTradeCenter.BackgroundServices
{
    public class CarScrapperSwissCarsAxa : CarScrapper
    {
        private readonly WebScrapperSwissCarsAxa WebScrpSwiss;

        public CarScrapperSwissCarsAxa(IServiceScopeFactory factory)
        {
            TimeFrequency = 2850000; //47min
            VehiclesToAddAtOnce = 20;
            Repo = factory.CreateScope().ServiceProvider.GetRequiredService<IRepositoryVehicle>();
            WebScrp = new Scrapper();
            this.WebScrpSwiss = new WebScrapperSwissCarsAxa();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                TryToAddVehicles(VehiclesToAddAtOnce, VehicleLimit);
                await Task.Delay(TimeFrequency);
            }
        }

        public override void TryToAddVehicles(int vehiclesToAdd, int vehicleLimit)
        {
            string mainPageRaw = GetMainPageRaw();
            //WebScrpSwiss.GetVehicleListFromMain(mainPageRaw, new List<Vehicle>());
            List<Vehicle> vehiclesFromDb = Repo.FindAllActive();
            int vehicleActiveTotal = vehiclesFromDb.Count();
            for (int i = 0; i < vehiclesToAdd; i++)
            {
                if (vehicleActiveTotal >= vehicleLimit)
                    return;
                try
                {
                    Vehicle vehicleUnique = WebScrpSwiss.GetUniqueVehicleFromMain(mainPageRaw, vehiclesFromDb);
                    Repo.Create(vehicleUnique);
                    vehiclesFromDb.Add(vehicleUnique);
                    vehicleActiveTotal++;
                }
                catch (Exception ex)
                {
                    string excDetails = ex.Message; //no new car will be created
                }
            }
        }

        private string GetMainPageRaw()
        {
            try
            {
                return WebScrp.GetPageTextRaw(WebScrpSwiss.URL);
            }
            catch (Exception ex)
            {
                throw new System.Exception("Swiss page probably does not responding. Error: " + ex.Message);
            }
        }

        public Vehicle GetUniqueVehicleFromMain(string pageTextRaw, List<Vehicle> vehiclesFromDb)
        {
            string[] vehiclesNode = pageTextRaw.Split('{');
            foreach (string vehicleNode in vehiclesNode)
            {
                if (vehicleNode.Contains("id"))
                {
                    try
                    {
                        Vehicle vhcIncomplete = new Vehicle();// WebScrpSwiss.GetVehicleMainFromNode(vehicleNode);
                        if (vhcIncomplete.IsCarUnique(vehiclesFromDb, vhcIncomplete))
                            return vhcIncomplete;// UpdateVehicleByExtras(vhcIncomplete);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            throw new System.Exception("No unique car found in main");
        }

    }
}