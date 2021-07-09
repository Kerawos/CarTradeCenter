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
    public class VehicleRemover : BackgroundService, IHostedService
    {

        private readonly IRepositoryVehicle Repo;
        private readonly int TimeFrequency = 3600000 * 24; //1day
        private readonly int TimeVehileAfterToBeRemovedInDays = 10;
        private readonly int CarLimit = 999;


        public VehicleRemover(IServiceScopeFactory factory)
        {
            this.Repo = factory.CreateScope().ServiceProvider.GetRequiredService<IRepositoryVehicle>();
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                RemoveVehiclesOlderThan(TimeVehileAfterToBeRemovedInDays, CarLimit);
                await Task.Delay(TimeFrequency);
            }
        }

        private void RemoveVehiclesOlderThan(int days, int carLimit)
        {
            
        }
    }
}
