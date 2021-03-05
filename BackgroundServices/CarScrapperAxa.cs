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
//        private readonly ICarDamagedRepository Repo;

//        public CarScrapperAxa(IServiceScopeFactory factory)
//        {
//            this.Repo = factory.CreateScope().ServiceProvider.GetRequiredService<ICarDamagedRepository>();
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
//            if (Repo.FindAll().Count() < limitCarsInTheDb)
//            {
//                try
//                {
//                    Repo.Create(GetUniqueCar());
//                }
//                catch
//                {

//                }
//            }
//        }

//        public CarDamaged GetUniqueCar()
//        {
//            string rawPage = scrapperAxa.GetPageTextRaw();
//            List<CarDamaged> cars = scrapperAxa.GetCarListFromMain(rawPage);
//            foreach (CarDamaged car in cars)
//            {
//                if(!Repo.FindById(car.Id).Equals(null)){
//                    return car;
//                }
//            }
//            throw new Exception("Unique car not found");
//        }


//    }
//}
