using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarTradeCenter.Contracts
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> FindAll();
        T FindById(int id);
        T FindByIdExternal(int idExternal);
    }
}
