using CarTradeCenter.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarTradeCenter.Data
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public int IdExternal { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime DateAuctionEnd { get; set; }
        public DateTime DateAuctionStart { get; set; }
        public string Url { get; set; }
        public bool IsDamaged { get; set; }
        public string DamageDescription { get; set; }
        
        public virtual List<Image> Images { get; set; }
        
        public Vehicle()
        {
            Images = new List<Image>();
        }

        public Image GetImageMini()
        {
            if (Images.Any())
                return Images.First();
            else
                throw new System.Exception("In Car: " + Title + " there is any ImageMini available.");
        }

        public string GetImageMiniUrl()
        {
            if (Images.Any())
                return Images.First().Url;
            else
                return "";
        }
            

    }
}
