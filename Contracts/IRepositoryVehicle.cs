using CarTradeCenter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarTradeCenter.Contracts
{
    public interface IRepositoryVehicle : IRepositoryBase<Vehicle>
    {
        IEnumerable<Vehicle> GetVehiclesByName(string name);
        bool Create(Vehicle entity);
        bool Update(Vehicle entity);
        bool Delete(Vehicle entity);
        bool Save();
        IEnumerable<Vehicle> FindAllByDamaged(bool isDamaged);
    }
}
