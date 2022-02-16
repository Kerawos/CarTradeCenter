using CarTradeCenter.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarTradeCenter.WebScrap
{
    public class WebScrapperSwissCarsAxa : WebScrapper, IWebScrapper
    {

        public WebScrapperSwissCarsAxa()
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
            String auctionEndS = Scrp.NodeCutter(subpageRaw, "DATA ZAKONCZENIA AUKCJI:", "<");
            return System.DateTime.Parse(auctionEndS);
        }

        public string GetCarNameDescription(string subpageRaw)
        {
            string preTitle = Scrp.NodeCutter(subpageRaw, "<a href=", ">");
            return Scrp.NodeCutter(preTitle, "title=\"");
        }

        public string GetCompanyProviderDescription(string subpageRaw)
        {
            return "Axa";
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
            return Int32.Parse(Scrp.NodeCutter(carNode, "samochody/", "/"));
        }

        public Image GetImageMini(string vehicleNode)
        {
            return new Image(URL.Substring(0, URL.Length - 1) + Scrp.NodeCutter(vehicleNode, "<img src=\"", "\""));
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
            string[] vehiclesNode = pageTextRaw.Split("<!--- Post Starts -->");
            foreach (string vehicleNode in vehiclesNode)
            {
                if (vehicleNode.Contains("DATA ZAKONCZENIA AUKCJI"))
                {
                    try
                    {
                        Vehicle vhcIncomplete = GetVehicleMainFromNode(vehicleNode);
                        if (vhcIncomplete.IsCarUnique(vehiclesFromDb, vhcIncomplete))
                            return vhcIncomplete;// UpdateVehicleByExtras(vhcIncomplete);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            throw new System.Exception("No unique car found in main");
        }

        public string GetURL(string vehicleNode)
        {
            return Scrp.NodeCutter(vehicleNode, "href=\"", "\">");
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

        public Vehicle GetVehicleMainFromNode(string vehicleNode)
        {
            Vehicle vhc = new Vehicle();
            vhc.Title = GetCarNameDescription(vehicleNode);
            vhc.Url = URL + GetURL(vehicleNode); //URL wkleja podwojne slash
            vhc.IdExternal = GetExternalId(vehicleNode);
            vhc.Images.Add(GetImageMini(vehicleNode));
            vhc.CompanyProvider = GetCompanyProviderDescription(vehicleNode);
            vhc.IsActive = true;
            vhc.IsArchived = false;
            return vhc;
        }
    }
}
