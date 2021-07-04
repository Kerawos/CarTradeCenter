using CarTradeCenter.Contracts;
using CarTradeCenter.Data.Models;
using CarTradeCenter.WebScrap;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace CarTradeCenter.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IRepositoryVehicle RepoVehicle;
        private readonly IRepositoryImage RepoImg;
        private readonly int PageSizeDefault = 30;

        public VehicleController(IRepositoryVehicle repoVehicle, IRepositoryImage repoImg)
        {
            this.RepoVehicle = repoVehicle;
            this.RepoImg = repoImg;

        }

        // GET: VehicleController
        public ActionResult Index(int pageNumber = 1)
        {
            List<Vehicle> vehicles = RepoVehicle.FindAll();
            RepoImg.UpdateAllImages(vehicles);
            return View(new PaginatedList<Vehicle>().CreateList(vehicles, pageNumber, PageSizeDefault));
        }


        [HttpGet]
        public ActionResult Index(string searchTerm, int pageNumber = 1)
        {
            List<Vehicle> vehicles;
            if (String.IsNullOrEmpty(searchTerm))
            {
                vehicles = RepoVehicle.FindAll();
            } else
            {
                vehicles = RepoVehicle.GetVehiclesByName(searchTerm);
            }
            RepoImg.UpdateAllImages(vehicles);
            return View(new PaginatedList<Vehicle>().CreateList(vehicles, pageNumber, PageSizeDefault));
        }


        public ActionResult IndexActive(int pageNumber = 1)
        {
            List<Vehicle> vehiclesActive = RepoVehicle.FindAllActive();
            RepoImg.UpdateAllImages(vehiclesActive);
            return View(new PaginatedList<Vehicle>().CreateList(vehiclesActive, pageNumber, PageSizeDefault));
        }


        public ActionResult IndexArchived(int pageNumber = 1)
        {
            List<Vehicle> vehiclesArchived = RepoVehicle.FindAllArchived();
            RepoImg.UpdateAllImages(vehiclesArchived);
            return View(new PaginatedList<Vehicle>().CreateList(vehiclesArchived, pageNumber, PageSizeDefault));
        }


        // GET: VehicleController/Details/5
        public ActionResult Details(int id)
        {
            Vehicle vhc = RepoVehicle.FindById(id);
            vhc.Images = RepoImg.GetImagesOfVehicle(vhc.Id);
            if (vhc == null)
                return NotFound();
            return View(vhc);
        }

        // GET: VehicleController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateAuto()
        {
            Vehicle dummyCar = new Vehicle();
            dummyCar.Title = "Test Car";
            Image im = new Image("https://cdn.group.renault.com/ren/master/renault-new-cars/product-plans/clio/bja-clio/hero-zone/640x600-mobile/renault-clio5-ph1-hero-zone-mobile-001.jpg.ximg.small.jpg/958ea02631.jpg");
            dummyCar.Images.Add(im);
            dummyCar.DateAuctionStart = DateTime.Now;
            dummyCar.DateAuctionEnd = DateTime.Now.AddDays(5);
            RepoVehicle.Create(dummyCar);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult CreateAutoAxa()
        {
            WebScrapper wScrp = new WebScrapper();
            WebScrapperAxa wScrpAxa = new WebScrapperAxa();
            string mainPageRaw = wScrp.GetPageTextRaw(WebScrapperAxa.URL_AXA_LIST);
            List<Vehicle> VehiclesFromDb = RepoVehicle.FindAll();
            try
            {
                Vehicle vehicleUnique = wScrpAxa.GetUniqueVehicleFromMain(mainPageRaw, VehiclesFromDb);
                RepoVehicle.Create(vehicleUnique);
            }
            catch (Exception ex)
            {
                string temp = ex.Message;
                temp = temp + "";
                //no new car will be created
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult CreateAutoAxa(int carsToAdd)
        {
            WebScrapper wScrp = new WebScrapper();
            WebScrapperAxa wScrpAxa = new WebScrapperAxa();
            string mainPageRaw = wScrp.GetPageTextRaw(WebScrapperAxa.URL_AXA_LIST);
            List<Vehicle> VehiclesFromDb = RepoVehicle.FindAll();

            for (int i = 0; i < carsToAdd; i++)
            {
                try
                {
                    Vehicle vehicleUnique = wScrpAxa.GetUniqueVehicleFromMain(mainPageRaw, VehiclesFromDb);
                    RepoVehicle.Create(vehicleUnique);
                    VehiclesFromDb.Add(vehicleUnique);
                }
                catch (Exception ex)
                {
                    string temp = ex.Message;
                    temp = temp + "";
                    //no new car will be created
                }
            }

            return RedirectToAction(nameof(Index));
        }


        public ActionResult CreateAutoAxa10()
        {
            WebScrapper wScrp = new WebScrapper();
            WebScrapperAxa wScrpAxa = new WebScrapperAxa();
            string mainPageRaw = wScrp.GetPageTextRaw(WebScrapperAxa.URL_AXA_LIST);
            List<Vehicle> VehiclesFromDb = RepoVehicle.FindAll();

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    Vehicle vehicleUnique = wScrpAxa.GetUniqueVehicleFromMain(mainPageRaw, VehiclesFromDb);
                    RepoVehicle.Create(vehicleUnique);
                    VehiclesFromDb.Add(vehicleUnique);
                }
                catch (Exception ex)
                {
                    string temp = ex.Message;
                    temp = temp + "";
                    //no new car will be created
                }
            }

            return RedirectToAction(nameof(Index));
        }




        // GET: VehicleController/Edit/5
        public ActionResult Edit(int id)
        {
            var car = RepoVehicle.FindById(id);
            if (car == null)
                return NotFound();
            return View(car);
        }

        // POST: VehicleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Vehicle model)
        {
            try
            {
                var isSuccess = RepoVehicle.Update(model);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Error during updating...");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //hard delete. Soft delete = inactivity in database
        // GET: VehicleController/Delete/5
        public ActionResult Delete(int id)
        {
            var car = RepoVehicle.FindById(id);
            if (car == null)
                return NotFound();

            foreach (Image im in RepoImg.GetImagesOfVehicle(car.Id))
                RepoImg.Delete(im);

            if (RepoVehicle.Delete(car))
                return RedirectToAction(nameof(Index));
            return BadRequest();
        }

        // POST: VehicleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Vehicle model)
        {
            try
            {
                var isSuccess = RepoVehicle.Delete(model);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Error during deleting...");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
