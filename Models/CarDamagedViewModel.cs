using CarTradeCenter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarTradeCenter.Models
{
    public class CarDamagedViewModel : VehicleViewModel
    {
        public string DamageDescription { get; set; }
        public IEnumerable<DamageType> Damages { get; set; }
    }
}
