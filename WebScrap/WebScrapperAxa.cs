using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CarTradeCenter.Data;
using CarTradeCenter.Data.Models;
using HtmlAgilityPack;


namespace CarTradeCenter.WebScrap
{
    public class WebScrapperAxa
    {
        public const string URL_AXA = "https://carauction.axa.ch/";
        public const string URL_AXA_LIST = URL_AXA + "auction/list/EN";
        private readonly WebScrapper WebScrp;

        public WebScrapperAxa()
        {
            this.WebScrp = new WebScrapper();
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
                        if(WebScrp.IsCarUnique(vehiclesFromDb, vhcIncomplete))
                            return UpdateVehicleByExtras(vhcIncomplete);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            throw new Exception("No unique car found in main");
        }


        private Vehicle GetVehicleMainFromNode(string vehicleNode)
        {
            Vehicle vhc = new Vehicle();
            vhc.Title = WebScrp.NodeCutter(vehicleNode, "at\":\"", "\",\"");
            vhc.Url = URL_AXA + WebScrp.NodeCutter(vehicleNode, "au\":\"", "\",\"");
            vhc.IdExternal = GetExternalId(vehicleNode);
            Image imMini = new Image(URL_AXA.Substring(0, URL_AXA.Length - 1) + WebScrp.NodeCutter(vehicleNode, "is\":\"", "\",\""));
            vhc.Images.Add(imMini);
            return vhc;
        }

        
        private Vehicle UpdateVehicleByExtras(Vehicle vhc)
        {
            string subPage = WebScrp.GetPageTextRaw(vhc.Url);
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
            string galleryRaw = WebScrp.NodeCutter(subPageRaw, "<!-- Gallery -->", "</ul>");
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
                    imUrl = WebScrp.NodeCutter(s, "src=", "alt=");
                    imUrl = imUrl.Replace("\"", "");
                    imUrl = imUrl.Replace("amp;", "");
                    imUrl = imUrl.Replace("/", "");
                    imUrl = URL_AXA + imUrl;
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
                string idExt = WebScrp.NodeCutter(carNode, "id\":\"", ",");
                idExt = idExt.Replace(":", "");
                idExt = idExt.Replace("\"", "");
                return Convert.ToInt32(idExt);
            }
            catch
            {
                throw new Exception("Cannot get externall ID");
            }
        }


        public DateTime GetAuctionEndTime(string subpageRaw)
        {
            try
            {
                string endTimeRaw = WebScrp.NodeCutter(subpageRaw, "data-seconds=", ">");
                endTimeRaw = endTimeRaw.Replace("\"", "");
                endTimeRaw = endTimeRaw.Replace("seconds=", "");
                return DateTime.Now.AddSeconds(Int32.Parse(endTimeRaw));
            }
            catch
            {
                throw new Exception("Cannot get auction end time");
            }
        }


        public string GetTextFromSubPageBasedOnPanelBodyDiv(string subpageRaw, string startNode, string endNode)
        {
            try
            {
                string desc = WebScrp.NodeCutter(subpageRaw, startNode, endNode);
                desc = WebScrp.NodeCutter(desc, "<div class=\"panel-body\">", "</div>");
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

    }
}
