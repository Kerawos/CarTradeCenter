using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarTradeCenter.Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        IEnumerable<T> FindAll();
        T FindById(int id);
        IEnumerable<T> GetVehiclesByName(string name);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool Save();
    }
}
