using System.Collections.Generic;


namespace CarTradeCenter.Contracts
{
    public interface IRepositoryBase<T>
    {
        List<T> FindAll();
        T FindById(int id);
        bool Delete(T entity);
        bool DeleteById(int entityId);
        bool Save();
    }
}
