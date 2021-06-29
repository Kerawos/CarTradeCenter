using CarTradeCenter.Contracts;
using CarTradeCenter.Data;
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
                //TryToAddVehicleDamagedFromAxa(20);
                TryToAddVehicles(10, CarLimit);
                await Task.Delay(60000);
            }
        }

        public void TryToAddVehicles(int vehiclesToAdd, int carsLimit)
        {
            string mainPageRaw = WebScrp.GetPageTextRaw(WebScrapperAxa.URL_AXA_LIST);
            List<Vehicle> VehiclesFromDb = Repo.FindAll();
            int carInDb = Repo.FindAll().Count();
            for (int i = 0; i < vehiclesToAdd; i++)
            {
                if (carInDb < carsLimit)
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

        //public void TryToAddVehicleDamagedFromAxa(int limitCarsInTheDb)
        //{
        //    int carInDb;
        //    try
        //    {
        //        carInDb = Repo.FindAll().Count();
        //        if (carInDb < limitCarsInTheDb)
        //        {
        //            try
        //            {
        //                Repo.Create(GetUniqueCar());
        //            }
        //            catch
        //            {

        //            }
        //        }
        //    }
        //    catch
        //    {
        //        try
        //        {
        //            Vehicle cd = GetUniqueCar();
        //            Repo.Create(cd);
        //        }
        //        catch
        //        {

        //        }

        //    }
        //}

        //public Vehicle GetUniqueCar()
        //{
        //    string rawPage = scrapperAxa.GetPageTextRaw();
        //    List<Vehicle> cars = scrapperAxa.GetCarListFromMain(rawPage);
        //    foreach (Vehicle car in cars)
        //    {
        //        try
        //        {
        //            var f = Repo.FindByIdExternal(car.IdExternal);
        //            bool found = !Repo.FindByIdExternal(car.IdExternal).Equals(null);

        //            if (!found)
        //            {
        //                return car;
        //            }
        //        }
        //        catch
        //        {
        //            return car;
        //        }

        //    }
        //    throw new Exception("Unique car not found");
        //}

        //public List<string> GetAllImagesOfVehicleFromPage()
        //{

        //    return "";
        //}


    }
}
