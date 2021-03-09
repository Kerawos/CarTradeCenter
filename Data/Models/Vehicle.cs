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
        public int IdExternal { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime DateAuctionEnd { get; set; }
        public DateTime DateAuctionStart { get; set; }
        public Image ImageMini { get; set; }
        public string Url { get; set; }
        public List<Image> Images { get; set; }
        

        protected Vehicle()
        {
        }

        protected Vehicle(int id, int idExternal, string title, DateTime dateAuctionEnd, DateTime dateAuctionStart, Image imageMini, string url)
        {
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
