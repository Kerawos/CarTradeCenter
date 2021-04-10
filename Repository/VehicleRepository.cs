using CarTradeCenter.Contracts;
using CarTradeCenter.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarTradeCenter.Repository
{
    public class VehicleRepository : IRepositoryVehicle
    {
        private readonly ApplicationDbContext Db;

        public VehicleRepository(ApplicationDbContext dbContext)
        {
            Db = dbContext;
        }

        public bool Create(Vehicle entity)
        {
            Db.Vehicles.Add(entity);
            return Save();
        }

        public bool Delete(Vehicle entity)
        {
            Db.Vehicles.Remove(entity);
            return Save();
        }

        public List<Vehicle> FindAll()
        {
            return Db.Vehicles.ToList();
        }

        public IEnumerable<Vehicle> FindAllByDamaged(bool isDamaged)
        {
            return Db.Vehicles
                .Where(v => v.IsDamaged == isDamaged)
                .ToList();
        }

        public Vehicle FindById(int id)
        {
            return Db.Vehicles.Find(id);
        }

        public Vehicle FindByIdExternal(int idExternal)
        {
            Vehicle cd = Db.Vehicles.Where(c => c.IdExternal == idExternal).First();
            return cd;   
        }

        public IEnumerable<Vehicle> GetVehiclesByName(string name)
        {
            return from c in Db.Vehicles
                   where
                    c.Title.ToLower().Contains(name.ToLower())
                   select c;
        }

        public bool Save()
        {
            return Db.SaveChanges() > 0;
        }

        public bool Update(Vehicle entity)
        {
            Db.Vehicles.Update(entity);
            return Save();
        }
    }
}
