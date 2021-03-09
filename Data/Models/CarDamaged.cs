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

        public CarDamaged(int id, int idExternal, string title, DateTime dateAuctionEnd, DateTime dateAuctionStart, Image imageMini, string url, string damageDescription) : base(id, idExternal, title, dateAuctionEnd, dateAuctionStart, imageMini, url)
        {
            DamageDescription = damageDescription;
            Id = id;
            IdExternal = idExternal;
            Title = title;
            DateAuctionEnd = dateAuctionEnd;
            DateAuctionStart = dateAuctionStart;
            ImageMini = imageMini;
            Url = url;
        }
    }
}
