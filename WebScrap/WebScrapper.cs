using CarTradeCenter.Data;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CarTradeCenter.WebScrap
{
    public class WebScrapper
    {
        private readonly HttpClient HttpClient;
        private readonly HtmlDocument HtmlDocument;

        public WebScrapper()
        {
            this.HttpClient = new HttpClient();
            this.HtmlDocument = new HtmlDocument();
        }


        public string GetPageTextRaw(string url)
        {
            var html = HttpClient.GetStringAsync(url).GetAwaiter().GetResult();
            HtmlDocument.LoadHtml(html);
            return HtmlDocument.Text.ToString();
        }


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
            if (vehiclesFromDB == null)
                return true;
            return !vehiclesFromDB.Any(v => v.IdExternal == vehicleToCheck.IdExternal);
        }


        public string NodeCutter(string node, string start, string end)
        {
            int cutStartPosition = node.IndexOf(start) + start.Length;
            string nodePart = node.Substring(cutStartPosition, node.Length - 1 - cutStartPosition);
            int cutEndPosition = nodePart.IndexOf(end);
            return nodePart.Substring(0, cutEndPosition);
        }

    }
}
