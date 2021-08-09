﻿using CarTradeCenter.Contracts;
using CarTradeCenter.Data.Models;
using CarTradeCenter.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


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
            try
            {
                return Db.Vehicles.Include(vehicle => vehicle.Images).OrderBy(vehicle => vehicle.DateAuctionEnd).ToList();
                //return Db.Vehicles.IgnoreAutoIncludes()
                //    .OrderBy(v => v.DateAuctionEnd).ToList();
            }
            catch (System.Exception ex)
            {

                return new List<Vehicle>(); //return empty list, if there is nothing in database
            }
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

        public List<Vehicle> GetVehiclesByName(string name)
        {
            return FindAll()
                .Where(v => v.Title.ToLower().Contains(name.ToLower()))
                .OrderBy(v => v.Title)
                .ToList();  
        }

        public List<Vehicle> GetVehiclesByName(string name, bool active)
        {
            if (active)
            {
                return FindAllActive()
                                .Where(v => v.Title.ToLower().Contains(name.ToLower()))
                                .OrderBy(v => v.Title)
                                .ToList();
            }
            else
            {
                return FindAllArchived()
                .Where(v => v.Title.ToLower().Contains(name.ToLower()))
                .OrderBy(v => v.Title)
                .ToList();
            }
            
        }

        public bool Save()
        {
            Db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Vehicles] ON");
            Db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Images] ON");
            Db.SaveChanges();
            Db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Vehicles] OFF");
            Db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Images] OFF");
            return true;
            //return Db.SaveChanges() > 0;
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
