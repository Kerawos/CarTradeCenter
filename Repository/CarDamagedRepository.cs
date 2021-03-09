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
        private readonly ApplicationDbContext Db;

        public CarDamagedRepository(ApplicationDbContext dbContext)
        {
            Db = dbContext;
        }

        public bool Create(CarDamaged entity)
        {
            Db.CarsDamaged.Add(entity);
            return Save();
        }

        public bool Delete(CarDamaged entity)
        {
            Db.CarsDamaged.Remove(entity);
            return Save();
        }

        public IEnumerable<CarDamaged> FindAll()
        {
            return Db.CarsDamaged.ToList();
        }

        public CarDamaged FindById(int id)
        {
            return Db.CarsDamaged.Find(id);
        }

        public CarDamaged FindByIdExternal(int idExternal)
        {
            CarDamaged cd = Db.CarsDamaged.Where(c => c.IdExternal == idExternal).First();
            return cd;   
        }

        public IEnumerable<CarDamaged> GetVehiclesByName(string name)
        {
            return from c in Db.CarsDamaged
                   where
                    c.Title.ToLower().Contains(name.ToLower())
                   select c;
        }

        public bool Save()
        {
            return Db.SaveChanges() > 0;
        }

        public bool Update(CarDamaged entity)
        {
            Db.CarsDamaged.Update(entity);
            return Save();
        }
    }
}
