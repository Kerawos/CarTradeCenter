using System;
using System.Collections.Generic;
using CarTradeCenter.Data;
using CarTradeCenter.Data.Models;


namespace CarTradeCenter.WebScrap
{
    public class WebScrapperAxa : WebScrapper, IWebScrapper
    {
        public string URL_AXA_LIST;


        public WebScrapperAxa()
        {
            Scrp = new Scrapper();
            URL = "https://carauction.axa.ch/";
            URL_AXA_LIST = URL + "auction/list/EN";
        }

        public List<Vehicle> GetVehicleListFromMain(string pageTextRaw)
        {
            List<Vehicle> vehicleList = new List<Vehicle>();
            string[] vehiclesNode = pageTextRaw.Split('{');
            foreach (string vehicleNode in vehiclesNode)
            {
                if (vehicleNode.Contains("id"))
                {
                    try
                    {
                        //vehicleList.Add(GetVehicleFromNode(vehicleNode));
                    }
                    catch
                    {
                        continue;
                    } 
                }
            }
            return vehicleList;
        }


        public Vehicle GetUniqueVehicleFromMain(string pageTextRaw, List<Vehicle> vehiclesFromDb)
        {
            Vehicle vhc = new Vehicle();
            string[] vehiclesNode = pageTextRaw.Split('{');
            foreach (string vehicleNode in vehiclesNode)
            {
                if (vehicleNode.Contains("id"))
                {
                    try
                    {
                        Vehicle vhcIncomplete = GetVehicleMainFromNode(vehicleNode);
                        if(vhc.IsCarUnique(vehiclesFromDb, vhcIncomplete))
                            return UpdateVehicleByExtras(vhcIncomplete);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            throw new System.Exception("No unique car found in main");
        }


        public Vehicle GetVehicleMainFromNode(string vehicleNode)
        {
            Vehicle vhc = new Vehicle();
            vhc.Title = Scrp.NodeCutter(vehicleNode, "at\":\"", "\",\"");
            vhc.Url = URL + Scrp.NodeCutter(vehicleNode, "au\":\"", "\",\"");
            vhc.IdExternal = GetExternalId(vehicleNode);
            Image imMini = new Image(URL.Substring(0, URL.Length - 1) + Scrp.NodeCutter(vehicleNode, "is\":\"", "\",\""));
            vhc.Images.Add(imMini);
            vhc.CompanyProvider = GetCompanyProviderDescription(vehicleNode);
            vhc.IsActive = true;
            vhc.IsArchived = false;
            return vhc;
        }

        
        private Vehicle UpdateVehicleByExtras(Vehicle vhc)
        {
            string subPage = Scrp.GetPageTextRaw(vhc.Url);
            vhc.DateAuctionStart = DateTime.Now;
            vhc.DateAuctionEnd = GetAuctionEndTime(subPage);
            vhc.InfoBasic = GetEquipmenSeriesDescription(subPage);
            vhc.InfoExtra = GetEquipmentOptionDescription(subPage);
            vhc.InfoDamage = GetDamageDescription(subPage);
            vhc.InfoUsableParts = GetUsableParts(subPage);
            vhc.IsDamaged = vhc.InfoDamage != "";
            vhc.Images.AddRange(GetImagesOfVehicle(subPage, 25));
            return vhc;
        }


        public List<Image> GetImagesOfVehicle(string subPageRaw, int maxImages)
        {
            string galleryRaw = Scrp.NodeCutter(subPageRaw, "<!-- Gallery -->", "</ul>");
            string[] galleryRawImages = galleryRaw.Split(new string[] { "<li" }, StringSplitOptions.None);
            List<Image> images = new List<Image>();
            string imUrl; int i = 1;
            foreach (string s in galleryRawImages)
            {
                if (i >= maxImages)
                    break;
                try
                {
                    i++;
                    imUrl = Scrp.NodeCutter(s, "src=", "alt=");
                    imUrl = imUrl.Replace("\"", "");
                    imUrl = imUrl.Replace("amp;", "");
                    if (imUrl.Substring(0, 1) == "/")                     
                        imUrl = imUrl.Remove(0, 1);
                    imUrl = URL + imUrl;
                    imUrl = imUrl.Replace("&wmk=&pfdrid_c=true", "");
                    images.Add(new Image(imUrl));
                }
                catch
                {
                    continue;
                }
            }
            return images;
        }


        public int GetExternalId(string carNode)
        {
            try
            {
                string idExt = Scrp.NodeCutter(carNode, "id\":\"", ",");
                idExt = idExt.Replace(":", "");
                idExt = idExt.Replace("\"", "");
                return Convert.ToInt32(idExt);
            }
            catch
            {
                throw new System.Exception("Cannot get externall ID");
            }
        }


        public DateTime GetAuctionEndTime(string subpageRaw)
        {
            try
            {
                string endTimeRaw = Scrp.NodeCutter(subpageRaw, "data-seconds=", ">");
                endTimeRaw = endTimeRaw.Replace("\"", "");
                endTimeRaw = endTimeRaw.Replace("seconds=", "");
                return DateTime.Now.AddSeconds(Int32.Parse(endTimeRaw));
            }
            catch
            {
                throw new System.Exception("Cannot get auction end time");
            }
        }


        public string GetTextFromSubPageBasedOnPanelBodyDiv(string subpageRaw, string startNode, string endNode)
        {
            try
            {
                string desc = Scrp.NodeCutter(subpageRaw, startNode, endNode);
                desc = Scrp.NodeCutter(desc, "<div class=\"panel-body\">", "</div>");
                return desc;
            }
            catch
            {
                return "";
            }
        }


        public string GetDamageDescription(string subpageRaw)
        {
            return GetTextFromSubPageBasedOnPanelBodyDiv(subpageRaw, "<!-- DAMAGE -->", "<!-- PRE DAMAGES -->");
        }


        public string GetUsableParts(string subpageRaw)
        {
            return GetTextFromSubPageBasedOnPanelBodyDiv(subpageRaw, "<!-- USABLE PART -->", "<!-- Fahrzeugbeschreibung -->");
        }


        public string GetEquipmentOptionDescription(string subpageRaw)
        {
            return GetTextFromSubPageBasedOnPanelBodyDiv(subpageRaw, "<!-- Sonder -->", "<!-- Ausstattung -->");
        }


        public string GetEquipmenSeriesDescription(string subpageRaw)
        {
            return GetTextFromSubPageBasedOnPanelBodyDiv(subpageRaw, "<!-- Serien -->", "<!-- Sonder -->");
        }

        public Vehicle GetVehicleFromSubpage(string vehicleNode)
        {
            throw new NotImplementedException();
        }

        public string GetCompanyProviderDescription(string subpageRaw)
        {
            return "Axa";
        }

        public string GetCarNameDescription(string subpageRaw)
        {
            throw new NotImplementedException();
        }

        public string Get1stRegDescription(string subpageRaw)
        {
            throw new NotImplementedException();
        }

        public string GetMileageDescription(string subpageRaw)
        {
            throw new NotImplementedException();
        }

    }
}
