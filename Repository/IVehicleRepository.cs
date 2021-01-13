using CarTradeCenter.Contracts;
using CarTradeCenter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarTradeCenter.Repository
{
    public interface IVehicleRepository : IRepositoryBase<Vehicle>
    {
        IEnumerable<Car> GetAllVehiclesUndamaged();
        IEnumerable<Car> GetVehiclesByName(string name);
        IEnumerable<CarDamaged> GetAllVehiclesDamaged();
        IEnumerable<CarDamaged> GetVehiclesDamagedByname(string name);
    }
}
