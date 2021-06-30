using CarTradeCenter.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarTradeCenter.BackgroundServices
{
    public class VehicleArchiver : BackgroundService, IHostedService
    {
        private readonly IRepositoryVehicle Repo;
        private readonly int Time1h = 6000000;
        private readonly int CarLimit = 9999;


        public VehicleArchiver(IServiceScopeFactory factory)
        {
            this.Repo = factory.CreateScope().ServiceProvider.GetRequiredService<IRepositoryVehicle>();
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                TryToArchiveVehicles(CarLimit);
                await Task.Delay(Time1h);
            }
        }


        private void TryToArchiveVehicles(int vehiclesToArchive)
        {

        }
    }
}
