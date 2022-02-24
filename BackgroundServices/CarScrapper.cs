using CarTradeCenter.Contracts;
using CarTradeCenter.WebScrap;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarTradeCenter.BackgroundServices
{
    public abstract class CarScrapper : BackgroundService, IHostedService, ICarScrapper
    {
        protected Scrapper WebScrp;
        protected IRepositoryVehicle Repo;
        protected int VehicleLimit = 9999;
        protected int TimeFrequency;
        protected int VehiclesToAddAtOnce;
        protected int TimeWaitMS;

        public abstract string GetPageRaw(string url);
        public abstract void TryToAddVehicles(int vehiclesToAdd, int vehicleLimit, int timeWaitMS);
    }
}
