using CarTradeCenter.Contracts;
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
    public class CarScrapperSwissCars : CarScrapper
    {
        private readonly WebScrapperSwissCars WebScrapperSwiss;


        public CarScrapperSwissCars(IServiceScopeFactory factory)
        {
            TimeFrequency = 2850000; //47min
            VehiclesToAddAtOnce = 20;
            Repo = factory.CreateScope().ServiceProvider.GetRequiredService<IRepositoryVehicle>();
            WebScrp = new Scrapper();
            this.WebScrapperSwiss = new WebScrapperSwissCars();
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
        }

        private string GetMainPageRaw()
        {
            try
            {
                return WebScrp.GetPageTextRaw(WebScrapperSwissCars.URL_SWISS);
            }
            catch (Exception ex)
            {
                throw new System.Exception("Swiss page probably does not responding.");
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
                        Vehicle vhcIncomplete = GetVehicleMainFromNode(vehicleNode);
                        if (WebScrp.IsCarUnique(vehiclesFromDb, vhcIncomplete))
                            return UpdateVehicleByExtras(vhcIncomplete);
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
