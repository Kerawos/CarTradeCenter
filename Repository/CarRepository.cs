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

        }

        public bool Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Car> FindAll()
        {
            throw new NotImplementedException();
        }

        public Car FindById(int id)
        {
            throw new NotImplementedException();
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
            return Db.SaveChanges();
        }

        public bool Update(Car entity)
        {
            throw new NotImplementedException();
        }
    }
}
