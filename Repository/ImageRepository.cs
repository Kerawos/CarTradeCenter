using CarTradeCenter.Contracts;
using CarTradeCenter.Data;
using CarTradeCenter.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarTradeCenter.Repository
{
    public class ImageRepository : IRepositoryImage
    {
        private readonly ApplicationDbContext Db;

        public ImageRepository(ApplicationDbContext db)
        {
            Db = db;
        }

        public IEnumerable<Image> FindAll()
        {
            return Db.Images.ToList();
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

        public List<Image> GetImagesOfCar(int CarID)
        {
            return FindAll()
                .Where(i => i.Vehicle.Id.Equals(CarID))
                .ToList();
        }
    }
}
