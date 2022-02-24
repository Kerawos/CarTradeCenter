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
    public class CarScrapperAxa : CarScrapper
    {

        private readonly WebScrapperAxa WebScrpAxa;

        public CarScrapperAxa(IServiceScopeFactory factory)
        {
            TimeFrequency = 2700000; //45min
            VehiclesToAddAtOnce = 20;
            Repo = factory.CreateScope().ServiceProvider.GetRequiredService<IRepositoryVehicle>();
            WebScrp = new Scrapper();
            this.WebScrpAxa = new WebScrapperAxa();
            TimeWaitMS = 1000; //1s
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                TryToAddVehicles(VehiclesToAddAtOnce, VehicleLimit, TimeWaitMS);
                await Task.Delay(TimeFrequency);
            }
        }


        public override void TryToAddVehicles(int vehiclesToAdd, int vehicleLimit, int timeWaitMS)
        {
            string mainPageRaw;
            try
            {
                mainPageRaw = WebScrp.GetPageTextRaw(WebScrpAxa.URL);
            } 
            catch (Exception ex)
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

        public override string GetPageRaw(string url)
        {
            throw new NotImplementedException();
        }
    }
}
