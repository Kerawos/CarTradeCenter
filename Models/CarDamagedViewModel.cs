using CarTradeCenter.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarTradeCenter.Models
{
    public class CarDamagedViewModel : VehicleViewModel
    {
        public string DamageDescription { get; set; }

        public CarDamagedViewModel()
        {
        }

        public CarDamagedViewModel(int id, int idExternal, string title, DateTime dateAuctionEnd, DateTime dateAuctionStart, string imageMini, string url, string damageDescription) : base(id, idExternal, title, dateAuctionEnd, dateAuctionStart, imageMini, url)
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
