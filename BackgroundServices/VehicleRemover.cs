﻿using CarTradeCenter.Contracts;
using CarTradeCenter.Data.Models;
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

        private readonly IRepositoryVehicle RepoVehicle;
        private readonly IRepositoryImage RepoImg;
        private readonly int TimeFrequency = 3600000 * 24; //1day
        private readonly int TimeVehileAfterToBeRemovedInDays = 10;
        private readonly int CarLimit = 999;


        public VehicleRemover(IServiceScopeFactory factory)
        {
            this.RepoVehicle = factory.CreateScope().ServiceProvider.GetRequiredService<IRepositoryVehicle>();
            this.RepoImg = factory.CreateScope().ServiceProvider.GetRequiredService<IRepositoryImage>();
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
            try
            {
                
                List<Vehicle> vehicleArchived = new List<Vehicle>();
                List<Image> images = RepoImg.FindAll();
                vehicleArchived = RepoVehicle.FindAllArchived();
                List<Image> images2 = RepoImg.FindAll();
                Image imw = images2.FirstOrDefault();
                List<Vehicle> vehiclesAll = RepoVehicle.FindAll();
                RepoImg.UpdateAllImages(vehicleArchived);
                List<Image> images3 = RepoImg.FindAll();
                for (int i = 0; i < vehicleArchived.Count || i > carLimit; i++)
                {
                    if (vehicleArchived[i].DateAuctionEnd.AddDays(days) < DateTime.Now)
                    {
                        foreach (Image im in RepoImg.GetImagesOfVehicle(vehicleArchived[i].Id))
                            RepoImg.Delete(im);
                        RepoVehicle.Delete(vehicleArchived[i]);
                    }
                }

            }
            catch (Exception ex)
            {
                string exDet = ex.Message;
            }


        }
    }
}
