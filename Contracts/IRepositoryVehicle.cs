using CarTradeCenter.Data.Models;
using System.Collections.Generic;


namespace CarTradeCenter.Contracts
{
    public interface IRepositoryVehicle : IRepositoryBase<Vehicle>
    {
        List<Vehicle> GetVehiclesByName(string name);
        List<Vehicle> GetVehiclesByName(string name, bool active);
        bool Create(Vehicle entity);
        bool Update(Vehicle entity);
        IEnumerable<Vehicle> FindAllByDamaged(bool isDamaged);
        Vehicle FindByIdExternal(int idExternal);
        List<Vehicle> FindAllActive();
        List<Vehicle> FindAllArchived();
    }
}
