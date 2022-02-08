using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarTradeCenter.WebScrap
{
    public class WebScrapperSwissCars
    {
        public const string URL_SWISS = "https://swisscars.pl/";
        
        private readonly WebScrapper WebScrp;

        public WebScrapperSwissCars()
        {
            this.WebScrp = new WebScrapper();
        }


    }
}
