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
    public class CarScrapperAxa : BackgroundService, IHostedService
    {
        private readonly WebScrapper WebScrp;
        private readonly WebScrapperAxa WebScrpAxa;
        private readonly IRepositoryVehicle Repo;
        private readonly int CarLimit = 9999;
        private readonly int Time20min = 1200000;


        public CarScrapperAxa(IServiceScopeFactory factory)
        {
            this.Repo = factory.CreateScope().ServiceProvider.GetRequiredService<IRepositoryVehicle>();
            this.WebScrp = new WebScrapper();
            this.WebScrpAxa = new WebScrapperAxa();
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                TryToAddVehicles(1, CarLimit);
                await Task.Delay(Time20min);
            }
        }


        public void TryToAddVehicles(int vehiclesToAdd, int carsLimit)
        {
            string mainPageRaw = WebScrp.GetPageTextRaw(WebScrapperAxa.URL_AXA_LIST);
            List<Vehicle> VehiclesFromDb = Repo.FindAll();
            for (int i = 0; i < vehiclesToAdd; i++)
            {
                if (Repo.FindAll().Count()>=carsLimit)
                    return;
                try
                {
                    Vehicle vehicleUnique = WebScrpAxa.GetUniqueVehicleFromMain(mainPageRaw, VehiclesFromDb);
                    Repo.Create(vehicleUnique);
                    VehiclesFromDb.Add(vehicleUnique);
                }
                catch (Exception ex)
                {
                    string temp = ex.Message;
                    temp = temp + "";
                    //no new car will be created
                }
            }
        }
    }
}
