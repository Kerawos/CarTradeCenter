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
        private readonly WebScrapper webScrapper;

        public WebScrapperAxa()
        {
            this.webScrapper = new WebScrapper();
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
                        vehicleList.Add(GetVehicleFromNode(vehicleNode));
                    }
                    catch
                    {
                        continue;
                    } 
                }
            }
            return vehicleList;
        }

        
        private Vehicle GetVehicleFromNode(string vehicleNode)
        {
            Vehicle vhc = new Vehicle();
            
            vhc.Title = webScrapper.NodeCutter(vehicleNode, "at\":\"", "\",\"");
            vhc.Url = URL_AXA + webScrapper.NodeCutter(vehicleNode, "au\":\"", "\",\"");
            vhc.IdExternal = GetExternalId(vehicleNode);
            Image im = new Image(URL_AXA.Substring(0, URL_AXA.Length - 1) + webScrapper.NodeCutter(vehicleNode, "is\":\"", "\",\""));
            vhc.Images.Add(im);

            string subPage = GetPageTextRaw(vhc.Url);
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

            string galleryRaw = NodeCutter(subPageRaw, "<!-- Gallery -->", "</ul>");
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
                    imUrl = NodeCutter(s, "src=", "alt=");
                    imUrl = imUrl + "";
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
                string idExt = NodeCutter(carNode, "id\":\"", ",");
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
                string endTimeRaw = NodeCutter(subpageRaw, "data-seconds=", ">");
                endTimeRaw = endTimeRaw.Replace("\"", "");
                endTimeRaw = endTimeRaw.Replace("seconds=", "");
                return DateTime.Now.AddSeconds(Int32.Parse(endTimeRaw));
            }
            catch
            {
                throw new Exception("Cannot get auction end time");
            }
        }


        public string GetDamageDescription(string subpageRaw)
        {
            try
            {
                string desc = NodeCutter(subpageRaw, "<!-- DAMAGE -->", "<!-- PRE DAMAGES -->");
                desc = NodeCutter(desc, "<div class=\"panel-body\">", "</div>");
                return desc;
            }
            catch
            {
                return "";
            }
        }


        public string GetUsableParts(string subpageRaw)
        {
            try
            {
                string desc = NodeCutter(subpageRaw, "<!-- USABLE PART -->", "<!-- Fahrzeugbeschreibung -->");
                desc = NodeCutter(desc, "<div class=\"panel-body\">", "</div>");
                return desc;
            }
            catch
            {
                return "";
            }
        }


        public string GetEquipmentOptionDescription(string subpageRaw)
        {
            try
            {
                string desc = NodeCutter(subpageRaw, "<!-- Sonder -->", "<!-- Ausstattung -->");
                desc = NodeCutter(desc, "<div class=\"panel-body\">", "</div>");
                return desc;
            }
            catch
            {
                return "";
            }
        }


        public string GetEquipmenSeriesDescription(string subpageRaw)
        {
            try
            {
                string desc = NodeCutter(subpageRaw, "<!-- Serien -->", "<!-- Sonder -->");
                desc = NodeCutter(desc, "<div class=\"panel-body\">", "</div>");
                return desc;
            }
            catch
            {
                return "";
            }
        }

    }
}
