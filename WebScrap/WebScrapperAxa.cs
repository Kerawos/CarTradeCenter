using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CarTradeCenter.Data;
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

        public List<CarDamaged> GetCarListFromMain(string pageTextRaw)
        {
            List<CarDamaged> carList = new List<CarDamaged>();
            string[] carsNode = pageTextRaw.Split('{');
            foreach (var carNode in carsNode)
            {
                if (carNode.Contains("id"))
                {
                    try
                    {
                        carList.Add(new CarDamaged(
                                        Convert.ToInt32(NodeCutter(carNode, "id", ",", false)),
                                        NodeCutter(carNode, "at", "\"", true),
                                        DateTime.Now.AddDays(30),
                                        DateTime.Now,
                                        URL_AXA.Substring(0, URL_AXA.Length - 1) + NodeCutter(carNode, "is", "\"", true),
                                        NodeCutter(carNode, "au", "\"", true),
                                        ""));
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
