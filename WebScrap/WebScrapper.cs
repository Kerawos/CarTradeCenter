using CarTradeCenter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarTradeCenter.WebScrap
{
    public class WebScrapper
    {
        public Vehicle GetUniqueCar(List<Vehicle> vehiclesFromPage, List<Vehicle> vehiclesFromDB)
        {
            foreach (Vehicle vehiclePage in vehiclesFromPage)
            {
                if (IsCarUnique(vehiclesFromDB, vehiclePage))
                    return vehiclePage;
            }
            throw new System.Exception("No Unique Vehicle Found");
        }

        public bool IsCarUnique(List<Vehicle> vehiclesFromDB, Vehicle vehicleToCheck)
        {
            return !vehiclesFromDB.Any(v => v.IdExternal == vehicleToCheck.IdExternal);
        }
    }
}
