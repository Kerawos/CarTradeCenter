using CarTradeCenter.Data;
using CarTradeCenter.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarTradeCenter.Contracts
{
    public interface IRepositoryImage : IRepositoryBase<Image>
    {
        List<Image> GetImagesOfCar(int CarID);
        List<Vehicle> UpdateAllImages(List<Vehicle> cars);
        Image FindByIdExternal(int idExternal);
    }
}
