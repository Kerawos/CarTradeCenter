using CarTradeCenter.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarTradeCenter.WebScrap
{
    public class WebScrapperSwissCars : WebScrapper, IWebScrapper
    {

        public WebScrapperSwissCars()
        {
            Scrp = new Scrapper();
            URL = "https://swisscars.pl/";
        }

        public string Get1stRegDescription(string subpageRaw)
        {
            throw new NotImplementedException();
        }

        public DateTime GetAuctionEndTime(string subpageRaw)
        {
            throw new NotImplementedException();
        }

        public string GetCarNameDescription(string subpageRaw)
        {
            throw new NotImplementedException();
        }

        public string GetCompanyProviderDescription(string subpageRaw)
        {
            throw new NotImplementedException();
        }

        public string GetDamageDescription(string subpageRaw)
        {
            throw new NotImplementedException();
        }

        public string GetEquipmenSeriesDescription(string subpageRaw)
        {
            throw new NotImplementedException();
        }

        public string GetEquipmentOptionDescription(string subpageRaw)
        {
            throw new NotImplementedException();
        }

        public int GetExternalId(string carNode)
        {
            throw new NotImplementedException();
        }

        public List<Image> GetImagesOfVehicle(string subPageRaw, int maxImages)
        {
            throw new NotImplementedException();
        }

        public string GetMileageDescription(string subpageRaw)
        {
            throw new NotImplementedException();
        }

        public Vehicle GetUniqueVehicleFromMain(string pageTextRaw, List<Vehicle> vehiclesFromDb)
        {
            throw new NotImplementedException();
        }

        public string GetUsableParts(string subpageRaw)
        {
            throw new NotImplementedException();
        }

        public Vehicle GetVehicleFromSubpage(string vehicleNode)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetVehicleListFromMain(string pageTextRaw)
        {
            throw new NotImplementedException();
        }
    }
}
