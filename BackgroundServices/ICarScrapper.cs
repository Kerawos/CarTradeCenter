﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarTradeCenter.BackgroundServices
{
    public interface ICarScrapper
    {
        void TryToAddVehicles(int vehiclesToAdd, int vehicleLimit, int timeWaitMS);
        string GetPageRaw(string url);
    }
}
