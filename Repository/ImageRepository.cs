﻿using CarTradeCenter.Contracts;
using CarTradeCenter.Data;
using CarTradeCenter.Data.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace CarTradeCenter.Repository
{
    public class ImageRepository : IRepositoryImage
    {
        private readonly ApplicationDbContext Db;

        public ImageRepository(ApplicationDbContext db)
        {
            Db = db;
        }


        public bool Delete(Image entity)
        {
            Db.Images.Remove(entity);
            return true;
        }


        public List<Image> FindAll()
        {
            try
            {
                return Db.Images.ToList();
            }
            catch
            {
                return Db.Images.ToList();
            }
        }

        public Image FindById(int id)
        {
            return Db.Images.Find(id);
        }

        public Image FindByIdExternal(int idExternal)
        {
            return FindAll()
                .Where(i => i.Vehicle.IdExternal.Equals(idExternal))
                .First();
        }

        
        public List<Image> GetImagesOfVehicle(int vehicleID)
        {
            return FindAll()
                .Where(i => i.Vehicle.Id.Equals(vehicleID))
                .ToList();
        }

        public List<Vehicle> UpdateAllImages(List<Vehicle> vehicles)
        {
            foreach (var vhc in vehicles)
                vhc.Images = GetImagesOfVehicle(vhc.Id);
            return vehicles;      
        }

        public bool Save()
        {
            return Db.SaveChanges() > 0;
        }

        public bool DeleteById(int entityId)
        {
            Db.Images.Remove(FindById(entityId));
            return true;
        }
    }
}
