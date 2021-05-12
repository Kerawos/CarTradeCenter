using CarTradeCenter.Data.Models;
using System.Collections.Generic;


namespace CarTradeCenter.Contracts
{
    public interface IRepositoryImage : IRepositoryBase<Image>
    {
        List<Image> GetImagesOfCar(int CarID);
        List<Vehicle> UpdateAllImages(List<Vehicle> cars);
        Image FindByIdExternal(int idExternal);
    }
}
