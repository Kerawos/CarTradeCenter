using CarTradeCenter.Contracts;
using CarTradeCenter.Data;
using CarTradeCenter.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarTradeCenter.BackgroundServices 
{
    public class CarScrapperTest : BackgroundService, IHostedService
    {
        private readonly Random rnd;
        private readonly ICarDamagedRepository Repo;


        public CarScrapperTest(IServiceScopeFactory factory)
        {
            this.rnd = new Random();
            this.Repo = factory.CreateScope().ServiceProvider.GetRequiredService<ICarDamagedRepository>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                TryToAddVehicleDamaged(10);
                await Task.Delay(60000);
            }
        }


        public void TryToAddVehicleDamaged(int limitCarsInTheDb)
        {
            if (Repo.FindAll().Count() < limitCarsInTheDb)
            {
                Repo.Create(CreateDummyCar());
            }
        }

        public CarDamaged CreateDummyCar()
        {
            return new CarDamaged
            {
                Title = "Car " + rnd.Next(),
                DateAuctionEnd = DateTime.Now.AddDays(30),
                DateAuctionStart = DateTime.Now,
                ImageMini = "https://upload.wikimedia.org/wikipedia/commons/b/b3/Ferrari348.jpg",
                DamageDescription = "brak uszkodzen"
            };

        }

    }

}
