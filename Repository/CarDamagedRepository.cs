using CarTradeCenter.Contracts;
using CarTradeCenter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarTradeCenter.Repository
{
    public class CarDamagedRepository : ICarDamagedRepository
    {
        private readonly ApplicationDbContext _db;

        public CarDamagedRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(CarDamaged entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(CarDamaged entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarDamaged> FindAll()
        {
            throw new NotImplementedException();
        }

        public CarDamaged FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarDamaged> GetAllVehiclesDamaged()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarDamaged> GetVehiclesDamagedByname(string name)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(CarDamaged entity)
        {
            throw new NotImplementedException();
        }
    }
}
