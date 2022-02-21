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
            MaxImg = 20;
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
            string nodeDmg = Scrp.NodeCutter(subpageRaw, "Beschädigungen", "Vorschaden");
            string dmg = Scrp.NodeCutter(nodeSeries, "panel-body\">", "</div>");
            return dmg;
        }

        public string GetDrive(string vehicleNode)
        {
            return GetDetailedInfo(vehicleNode, "Antrieb");
        }

        public string GetEngine(string vehicleNode)
        {
            return GetDetailedInfo(vehicleNode, "Hubraum");
        }

        public string GetEquipmenSeriesDescription(string subpageRaw)
        {
            throw new NotImplementedException();

        }

        public string GetEquipmentOptionDescription(string subpageRaw)
        {
            string nodeSeries = Scrp.NodeCutter(subpageRaw, "Serienausstattung", "Beschädigungen");
            string series = Scrp.NodeCutter(nodeSeries, "panel-body\">", "</div>");
            return series;
            
        }

        public int GetExternalId(string carNode)
        {
            return Int32.Parse(Scrp.NodeCutter(carNode, "samochody/", "/"));
        }

        public string GetGasType(string vehicleNode)
        {
            return GetDetailedInfo(vehicleNode, "Treibstoff");
        }

        public string GetGearbox(string vehicleNode)
        {
            return GetDetailedInfo(vehicleNode, "Getriebe");
        }

        public Image GetImageMini(string vehicleNode)
        {
            return new Image(URL.Substring(0, URL.Length - 1) + Scrp.NodeCutter(vehicleNode, "<img src=\"", "\""));
        }

        public List<Image> GetImagesOfVehicle(string subPageRaw, int maxImages)
        {
            List<Image> images = new List<Image>();
            string[] nodes = subPageRaw.Split("<img class=");
            foreach (string node in nodes)
            {
                if (node.Contains("aligncenter size-full"))
                {
                    images.Add(new Image(URL + Scrp.NodeCutter(node, "src=\"/", "\"")));
                }
            }
            return images;
        }


        public string GetDetailedInfo(string node, string detail)
        {
            string[] trs = node.Split("<tr>");
            foreach (string tr in trs)
            {
                if (tr.Contains(detail))
                {
                    return Scrp.NodeCutter(tr, detail +"</td><td>", "</td>");
                }
            }
            return "";
        }

        public string GetMileage(string vehicleNode)
        {
            return GetDetailedInfo(vehicleNode, "Kilometerstand");
        }

        public string GetMileageDescription(string subpageRaw)
        {
            throw new NotImplementedException();
        }

        public string GetRegistration1stDate(string vehicleNode)
        {
            return GetDetailedInfo(vehicleNode, "1.Inv.");
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
            return Scrp.NodeCutter(vehicleNode, "<a href=\"/", "/\"");
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
            vhc.Url = URL + GetURL(vehicleNode);
            vhc.IdExternal = GetExternalId(vehicleNode);
            vhc.Images.Add(GetImageMini(vehicleNode));
            vhc.CompanyProvider = GetCompanyProviderDescription(vehicleNode);
            vhc.DateAuctionEnd = GetAuctionEndTime(vehicleNode);
            vhc.IsActive = true;
            vhc.IsArchived = false;
            return vhc;
        }


        public Vehicle UpdateVehicleFromSubpage(Vehicle vhcToUpdate, string subpageTextRaw)
        {
            vhcToUpdate.Images.AddRange(GetImagesOfVehicle(subpageTextRaw, MaxImg));
            string detailNode = Scrp.NodeCutter(subpageTextRaw, "articledetail", "table");
            string nodeWoutWhite = DeleteWhiteChars(detailNode);
            vhcToUpdate.Registration1stDate = GetRegistration1stDate(nodeWoutWhite);
            vhcToUpdate.Mileage = GetMileage(nodeWoutWhite);
            vhcToUpdate.Gearbox = GetGearbox(nodeWoutWhite);
            vhcToUpdate.Drive = GetDrive(nodeWoutWhite);
            vhcToUpdate.GasType = GetGasType(nodeWoutWhite);
            vhcToUpdate.Engine = GetEngine(nodeWoutWhite);
            vhcToUpdate.PriceBrandNew = GetPriceBrandNew(nodeWoutWhite);
            vhcToUpdate.InfoExtra = GetEquipmentOptionDescription(subpageTextRaw);
            vhcToUpdate.PriceRepairCost = GetPriceRepairCost(subpageTextRaw);
            vhcToUpdate.InfoDamage = GetDamageDescription(subpageTextRaw);
            //te same metody - do jednej! jutro todo
            
            return vhcToUpdate;
                
        }


        public string DeleteWhiteChars(string blackText)
        {
            return String.Concat(blackText.Where(c => !Char.IsWhiteSpace(c)));
        }

        public string GetPriceBrandNew(string vehicleNode)
        {
            return GetDetailedInfo(vehicleNode, "Fahrzeug-Neupreis");
        }

        public string GetPriceRepairCost(string vehicleNode)
        {
            string nodeCost = Scrp.NodeCutter(vehicleNode, "Reparaturkosten ", "Unfallfrei ");
            nodeCost = DeleteWhiteChars(nodeCost);
            string cost = Scrp.NodeCutter(nodeCost, "CHF", "</td>");
            return cost;
        }
    }
}
