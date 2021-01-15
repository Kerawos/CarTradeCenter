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
        public Image Image { get; set; }
    }
}
