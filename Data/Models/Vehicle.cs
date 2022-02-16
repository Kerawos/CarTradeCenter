using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CarTradeCenter.Data.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdExternal { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime DateAuctionEnd { get; set; }
        public DateTime DateAuctionStart { get; set; }
        [Required]
        public string Url { get; set; }
        public string InfoGeneralDesc { get; set; }
        public string InfoBasic { get; set; }
        public string InfoExtra { get; set; }
        public string InfoUsableParts { get; set; }
        public bool IsDamaged { get; set; }
        public string InfoDamage { get; set; }
        public virtual List<Image> Images { get; set; }
        [Required]
        public string CompanyProvider { get; set; }
        public bool IsActive { get; set; }
        public bool IsArchived { get; set; }


        public Vehicle()
        {
            Images = new List<Image>();
        }


        public string GetImageMiniUrl()
        {
            if (Images.Any())
                return Images
                    //.Where(i => i.Url.Contains("PREMIUM"))
                    .First().Url;
            else
                return "";
        }


        public Vehicle GetUniqueCar(List<Vehicle> vehiclesFromPage, List<Vehicle> vehiclesFromDB)
        {
            foreach (Vehicle vehiclePage in vehiclesFromPage)
            {
                if (IsCarUnique(vehiclesFromDB, vehiclePage))
                    return vehiclePage;
            }
            throw new System.Exception("No Unique Vehicle Found");
        }


        public bool IsCarUnique(List<Vehicle> vehiclesFromDB, Vehicle vehicleToCheck)
        {
            if (vehiclesFromDB == null)
                return true;
            return !vehiclesFromDB.Any(v => v.IdExternal == vehicleToCheck.IdExternal);
        }
    }
}
