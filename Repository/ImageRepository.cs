using CarTradeCenter.Contracts;
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
            try
            {


                List<Image> im = Db.Images.Include("Vehicle").ToList();
                List<Image> im2 = Db.Images.ToList();
                List<Image> im3 = Db.Images.Include(x => x.Vehicle).ToList();
                List<Image> im4 = Db.Images.Include(x => x.Vehicle.Images).ToList();
                //List<Image> im5 = Db.Images.Include(x => x.Vehicle.Id).ThenInclude
                //List<Image> im6 = Db.Images.Include(x=> x.Vehicle.Select(y=>y.))
                return im2;
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

            List<Image> images = FindAll();
            images = images.Where(i => i.Vehicle.Id.Equals(vehicleID)).ToList();
            return images;

            //return FindAll()
            //    .Where(i => i.Vehicle.Id.Equals(vehicleID))
            //    .ToList();
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
