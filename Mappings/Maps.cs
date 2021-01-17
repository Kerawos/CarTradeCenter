using AutoMapper;
using CarTradeCenter.Data;
using CarTradeCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarTradeCenter.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Car, CarViewModel>();
            CreateMap<CarDamaged, CarDamagedViewModel>();
            CreateMap<Image, ImageViewModel>();
            CreateMap<Vehicle, VehicleViewModel>();
        }
    }
}
