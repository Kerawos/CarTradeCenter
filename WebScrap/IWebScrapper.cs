using CarTradeCenter.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarTradeCenter.WebScrap
{
    interface IWebScrapper
    {
        List<Vehicle> GetVehicleListFromMain(string pageTextRaw);
        Vehicle GetUniqueVehicleFromMain(string pageTextRaw, List<Vehicle> vehiclesFromDb);
        Vehicle GetVehicleFromSubpage(string vehicleNode);
        Vehicle GetVehicleMainFromNode(string vehicleNode);


        string GetCompanyProviderDescription(string subpageRaw);
        int GetExternalId(string carNode);
        string GetCarNameDescription(string subpageRaw);
        string Get1stRegDescription(string subpageRaw);
        string GetMileageDescription(string subpageRaw);
        DateTime GetAuctionEndTime(string subpageRaw);
        string GetDamageDescription(string subpageRaw);
        string GetUsableParts(string subpageRaw);
        string GetEquipmentOptionDescription(string subpageRaw);
        string GetEquipmenSeriesDescription(string subpageRaw);
        List<Image> GetImagesOfVehicle(string subPageRaw, int maxImages);
    }
}
