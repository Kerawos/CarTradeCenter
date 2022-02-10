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

        public List<Vehicle> GetVehicleListFromMain(string pageTextRaw, List<Vehicle> vehiclesFromDb)
        {
            Vehicle vhc = new Vehicle();
            string[] vehiclesNode = pageTextRaw.Split("<!--- Post Starts -->");
            foreach (string vehicleNode in vehiclesNode)
            {
                if (vehicleNode.Contains("DATA ZAKONCZENIA AUKCJI"))
                {
                    try
                    {
                        Vehicle vhcIncomplete = GetVehicleMainFromNode(vehicleNode);
                        if (vhc.IsCarUnique(vehiclesFromDb, vhcIncomplete))
                            return vehiclesFromDb;// UpdateVehicleByExtras(vhcIncomplete);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            throw new System.Exception("No unique car found in main");
        }

        public List<Vehicle> GetVehicleListFromMain(string pageTextRaw)
        {
            throw new NotImplementedException();
        }

        public Vehicle GetVehicleMainFromNode(string vehicleNode)
        {
            Vehicle vhc = new Vehicle();
            string preTitle = Scrp.NodeCutter(vehicleNode, "<a href=", ">");
            vhc.Title = Scrp.NodeCutter(preTitle, "title=\"");
            vhc.Url = URL + Scrp.NodeCutter(vehicleNode, "au\":\"", "\",\"");
            vhc.IdExternal = GetExternalId(vehicleNode);
            Image imMini = new Image(URL.Substring(0, URL.Length - 1) + Scrp.NodeCutter(vehicleNode, "is\":\"", "\",\""));
            vhc.Images.Add(imMini);
            vhc.CompanyProvider = GetCompanyProviderDescription(vehicleNode);
            vhc.IsActive = true;
            vhc.IsArchived = false;
            return vhc;
        }
    }
}
