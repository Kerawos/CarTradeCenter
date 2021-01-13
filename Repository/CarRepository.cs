using CarTradeCenter.Contracts;
using CarTradeCenter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarTradeCenter.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext Db;

        public CarRepository(ApplicationDbContext dbContext)
        {
            Db = dbContext;
        }

        public bool Create(Car entity)
        {
            Db.Cars.Add(Car);
            return Save();
        }

        public bool Delete(Car entity)
        {
            Db.Cars.Remove(entity);
            return Save();
        }

        public IEnumerable<Car> FindAll()
        {
            return Db.Cars.ToList();
        }

        public Car FindById(int id)
        {
            return Db.Cars.Find(id);
        }

        public IEnumerable<Car> GetAllVehiclesUndamaged()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Car> GetVehiclesByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            return Db.SaveChanges() > 0;
        }

        public bool Update(Car entity)
        {
            Db.Cars.Update(Car);
            return Save();
        }
    }
}
