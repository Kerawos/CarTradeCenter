using CarTradeCenter.Contracts;
using CarTradeCenter.Data.Models;
using CarTradeCenter.Data;
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
            return Db.Vehicles.OrderBy(v=>v.DateAuctionEnd).ToList();
        }

        public IEnumerable<Vehicle> FindAllByDamaged(bool isDamaged)
        {
            return FindAll()
                .Where(v => v.IsDamaged == isDamaged)
                .ToList();
        }

        public Vehicle FindById(int id)
        {
            return FindAll().Find(v=> v.Id==id);
        }

        public Vehicle FindByIdExternal(int idExternal)
        {
            Vehicle vhc = FindAll().Where(v => v.IdExternal == idExternal).First();
            return vhc;   
        }

        public IEnumerable<Vehicle> GetVehiclesByName(string name)
        {
            return from v in FindAll()
                   where v.Title.ToLower().Contains(name.ToLower())
                   orderby v.Title
                   select v;
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

        public List<Vehicle> FindAllActive()
        {
            return FindAll()
                .Where(v => v.IsActive == true)
                .ToList();
        }

        public List<Vehicle> FindAllArchived()
        {
            return FindAll()
                .Where(v => v.IsArchived == true)
                .ToList();
        }
    }
}
