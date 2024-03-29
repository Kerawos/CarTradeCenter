﻿using CarTradeCenter.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarTradeCenter.WebScrap
{
    interface IWebScrapper
    {
        //List<Vehicle> GetVehicleListFromMain(string pageTextRaw);
        Vehicle GetUniqueVehicleFromMain(string pageTextRaw, List<Vehicle> vehiclesFromDb);
        Vehicle UpdateVehicleFromSubpage(Vehicle vhcToUpdate, string subpageTextRaw);
        Vehicle GetVehicleFromSubpage(string vehicleNode);
        Vehicle GetVehicleMainFromNode(string vehicleNode);


        string GetCompanyProviderDescription(string vehicleNode);
        int GetExternalId(string vehicleNode);
        string GetCarNameDescription(string vehicleNode);
        string Get1stRegDescription(string vehicleNode);
        string GetMileageDescription(string vehicleNode);
        DateTime GetAuctionEndTime(string vehicleNode);
        string GetDamageDescription(string vehicleNode);
        string GetUsableParts(string vehicleNode);
        string GetEquipmentOptionDescription(string vehicleNode);
        string GetEquipmenSeriesDescription(string vehicleNode);
        string GetURL(string vehicleNode);
        string GetRegistration1stDate(string vehicleNode);
        string GetMileage(string vehicleNode);
        string GetGearbox(string vehicleNode);
        string GetDrive(string vehicleNode);
        string GetGasType(string vehicleNode);
        string GetEngine(string vehicleNode);
        string GetPriceBrandNew(string vehicleNode);
        string GetPriceRepairCost(string vehicleNode);
        List<Image> GetImagesOfVehicle(string vehicleNode, int maxImages);
        Image GetImageMini(string vehicleNode);
        string DeleteWhiteChars(string blackText);
    }
}
