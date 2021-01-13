using CarTradeCenter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarTradeCenter.Contracts
{
    public interface ICarDamagedRepository : IRepositoryBase<CarDamaged>
    {
        IEnumerable<CarDamaged> GetAllVehiclesDamaged();
        IEnumerable<CarDamaged> GetVehiclesDamagedByname(string name);
    }
}
