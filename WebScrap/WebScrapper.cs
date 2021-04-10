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
            foreach (Vehicle vehicleDb in vehiclesFromDB)
            {
                foreach (Vehicle vehiclePage in vehiclesFromPage)
                {
                    if (vehicleDb.IdExternal != vehiclePage.IdExternal)
                        return vehiclePage;
                }
            }
            throw new System.Exception("No Unique Vehicle Found");
        }
    }
}
