//using CarTradeCenter.Contracts;
//using CarTradeCenter.Data;
//using CarTradeCenter.WebScrap;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;

//namespace CarTradeCenter.BackgroundServices
//{
//    public class CarScrapperAxa : BackgroundService, IHostedService
//    {
//        private readonly WebScrapperAxa scrapperAxa = new WebScrapperAxa();
//        private readonly IRepositoryVehicle Repo;

//        public CarScrapperAxa(IServiceScopeFactory factory)
//        {
//            this.Repo = factory.CreateScope().ServiceProvider.GetRequiredService<IRepositoryVehicle>();
//        }
//        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
//        {
//            while (!stoppingToken.IsCancellationRequested)
//            {
//                TryToAddVehicleDamagedFromAxa(20);
//                await Task.Delay(60000);
//            }
//        }

//        public void TryToAddVehicleDamagedFromAxa(int limitCarsInTheDb)
//        {
//            int carInDb;
//            try
//            {
//                carInDb = Repo.FindAll().Count();
//                if (carInDb < limitCarsInTheDb)
//                {
//                    try
//                    {
//                        Repo.Create(GetUniqueCar());
//                    }
//                    catch
//                    {

//                    }
//                }
//            }
//            catch
//            {
//                try
//                {
//                    Vehicle cd = GetUniqueCar();
//                    Repo.Create(cd);
//                }
//                catch
//                {

//                }

//            }
//        }

//        public Vehicle GetUniqueCar()
//        {
//            string rawPage = scrapperAxa.GetPageTextRaw();
//            List<Vehicle> cars = scrapperAxa.GetCarListFromMain(rawPage);
//            foreach (Vehicle car in cars)
//            {
//                try
//                {
//                    var f = Repo.FindByIdExternal(car.IdExternal);
//                    bool found = !Repo.FindByIdExternal(car.IdExternal).Equals(null);
                    
//                    if (!found)
//                    {
//                        return car;
//                    }
//                }
//                catch
//                {
//                    return car;
//                }
                
//            }
//            throw new Exception("Unique car not found");
//        }

//        public List<string> GetAllImagesOfVehicleFromPage()
//        {

//            return "";
//        }


//    }
//}
