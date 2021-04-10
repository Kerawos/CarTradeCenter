using CarTradeCenter.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarTradeCenter.Contracts
{
    interface IRepositoryImage : IRepositoryBase<Image>
    {
        List<Image> GetImagesOfCar(int CarID);
    }
}
