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
            return Save();
        }

        public List<Image> FindAll()
        {
            //return Db.Images.ToList();

            try
            {
                //return Db.Images.IgnoreAutoIncludes().ToList();
                return Db.Images.Include("Vehicle").ToList();
            }
            catch (System.Exception ex)
            {
                string exz = ex.Message;

                return new List<Image>(); //return empty list, if there is nothing in database
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
            List<Image> images = FindAll();
            return images
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
    }
}
