using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarTradeCenter.Data
{
    public abstract class Vehicle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime DateAuctionEnd { get; set; }
        public DateTime DateAuctionStart { get; set; }
        public string ImageMini { get; set; }
        public string Url { get; set; }

        protected Vehicle()
        {
        }

        protected Vehicle(int id, string title, DateTime dateAuctionEnd, DateTime dateAuctionStart, string imageMini, string url)
        {
            Id = id;
            Title = title;
            DateAuctionEnd = dateAuctionEnd;
            DateAuctionStart = dateAuctionStart;
            ImageMini = imageMini;
            Url = url;
        }
    }
}
