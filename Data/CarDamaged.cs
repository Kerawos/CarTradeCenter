using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarTradeCenter.Data
{
    public class CarDamaged : Vehicle   
    {
        public string DamageDescription  { get; set; }

        public CarDamaged()
        {
        }

        public CarDamaged(int id, string title, DateTime dateAuctionEnd, DateTime dateAuctionStart, string imageMini, string url, string damageDescription) : base(id, title, dateAuctionEnd, dateAuctionStart, url, imageMini)
        {
            DamageDescription = damageDescription;
            Id = id;
            Title = title;
            DateAuctionEnd = dateAuctionEnd;
            DateAuctionStart = dateAuctionStart;
            ImageMini = imageMini;
            Url = url;
        }
    }
}
