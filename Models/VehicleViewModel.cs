using CarTradeCenter.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarTradeCenter.Models
{
    public abstract class VehicleViewModel
    {
        [Key]
        public int Id { get; set; }
        public int IdExternal { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime DateAuctionEnd { get; set; }
        public DateTime DateAuctionStart { get; set; }
        //public Image Image { get; set; }
        public string ImageMini { get; set; }
        public string Url { get; set; }

        protected VehicleViewModel()
        {
        }

        protected VehicleViewModel(int id, int idExternal, string title, DateTime dateAuctionEnd, DateTime dateAuctionStart, string imageMini, string url)
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
