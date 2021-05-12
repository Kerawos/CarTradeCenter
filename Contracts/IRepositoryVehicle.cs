using CarTradeCenter.Data.Models;
using System.Collections.Generic;


namespace CarTradeCenter.Contracts
{
    public interface IRepositoryVehicle : IRepositoryBase<Vehicle>
    {
        IEnumerable<Vehicle> GetVehiclesByName(string name);
        bool Create(Vehicle entity);
        bool Update(Vehicle entity);
        IEnumerable<Vehicle> FindAllByDamaged(bool isDamaged);
        Vehicle FindByIdExternal(int idExternal);
    }
}
