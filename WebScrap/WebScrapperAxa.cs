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

        public string GetPageTextRaw(string url)
        {
            var html = httpClient.GetStringAsync(url).GetAwaiter().GetResult();
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            return htmlDocument.Text.ToString();   
        }

        public List<CarDamaged> GetCarListFromMain(string pageTextRaw)
        {
            string[] carsNode = pageTextRaw.Split('{');
            CarDamaged carToAdd;
            foreach (var carNode in carsNode)
            {
                if (carNode.Contains("id"))
                {
                    try
                    {
                        carToAdd = new CarDamaged(
                                                Convert.ToInt32(NodeCutter(carNode, "id", ",", false)),
                                                NodeCutter(carNode, "at", "\"", true),
                                                DateTime.Now.AddDays(30),
                                                DateTime.Now,
                                                URL_AXA + NodeCutter(carNode, "is", "\"", true),
                                                "");
                    }
                    catch
                    {

                    }

 

                }
            }
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
