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
    public class CarScrapperAxa : BackgroundService, IHostedService
    {
        private readonly WebScrapper WebScrp;
        private readonly WebScrapperAxa WebScrpAxa;
        private readonly IRepositoryVehicle Repo;
        private readonly int VehicleLimit = 9999;
        private readonly int TimeFrequency = 2700000; //45min
        private readonly int VehiclesToAddAtOnce = 20;


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
                TryToAddVehicles(VehiclesToAddAtOnce, VehicleLimit);
                await Task.Delay(TimeFrequency);
            }
        }


        public void TryToAddVehicles(int vehiclesToAdd, int vehicleLimit)
        {
            string mainPageRaw;
            try
            {
                mainPageRaw = WebScrp.GetPageTextRaw(WebScrapperAxa.URL_AXA_LIST);
            } catch (Exception ex)
            {
                string excDetails = ex.Message; // axa page probably does not responding
                return;
            }
            
            List<Vehicle> vehiclesFromDb = Repo.FindAllActive();
            int vehicleActiveTotal = vehiclesFromDb.Count();
            for (int i = 0; i < vehiclesToAdd; i++)
            {
                if (vehicleActiveTotal >= vehicleLimit)
                    return;
                try
                {
                    Vehicle vehicleUnique = WebScrpAxa.GetUniqueVehicleFromMain(mainPageRaw, vehiclesFromDb);
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
    }
}
