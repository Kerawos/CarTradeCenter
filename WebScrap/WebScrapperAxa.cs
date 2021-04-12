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
        private readonly HttpClient httpClient;

        public WebScrapperAxa()
        {
            this.httpClient = new HttpClient();
        }

        public string GetPageTextRaw()
        {
            var html = httpClient.GetStringAsync(URL_AXA_LIST).GetAwaiter().GetResult();
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            return htmlDocument.Text.ToString();   
        }

        public List<Vehicle> GetCarListFromMain(string pageTextRaw)
        {
            List<Vehicle> carList = new List<Vehicle>();
            string[] carsNode = pageTextRaw.Split('{');
            Vehicle cd;
            foreach (var carNode in carsNode)
            {
                if (carNode.Contains("id"))
                {
                    try
                    {
                        cd = new Vehicle
                        {
                            Title = NodeCutter(carNode, "at", "\"", true),
                            DateAuctionEnd = DateTime.Now.AddDays(30),
                            DateAuctionStart = DateTime.Now,
                            DamageDescription = "no damage",
                            Url = NodeCutter(carNode, "au", "\"", true),
                            IdExternal = Convert.ToInt32(NodeCutter(carNode, "id", ",", false)),
                        };
                        Image im = new Image(URL_AXA.Substring(0, URL_AXA.Length - 1) + NodeCutter(carNode, "is", "\"", true));
                        //cd.Images.Append<Image>(im);
                        cd.Images.Add(im);
                        carList.Add(cd);

                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            return carList;
        }

        public string NodeCutter(string node, string start, string end, bool isQuotes)
        {
            int cutPosition;
            if (isQuotes)
                cutPosition = node.IndexOf(start) + 5;
            else
                cutPosition = node.IndexOf(start) + 4;
            string part = node.Substring(cutPosition, node.Length - 1 - cutPosition);
            cutPosition = part.IndexOf(end);
            return part.Substring(0, cutPosition);
        }
    }
}
