using AutoMapper;
using CarTradeCenter.Contracts;
using CarTradeCenter.Data;
using CarTradeCenter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarTradeCenter.Controllers
{
    public class CarDamagedController : Controller
    {
        private readonly ICarDamagedRepository Repo;
        private readonly IMapper Mapper;

        public CarDamagedController(ICarDamagedRepository carDamagedRepository, IMapper mapper)
        {
            Mapper = mapper;
            Repo = carDamagedRepository;
        }

        // GET: CarDamagedController
        public ActionResult Index()
        {
            var carsDamaged = Repo.FindAll();
            var model = Mapper.Map<IEnumerable<CarDamaged>, IEnumerable<CarDamagedViewModel>> (carsDamaged);
            return View(model);
        }

        // GET: CarDamagedController/Details/5
        public ActionResult Details(int id)
        {
            var car = Repo.FindById(id);
            if (car == null)
                return NotFound();
            return View(car);
        }

        // GET: CarDamagedController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarDamagedController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarDamaged car)
        {
            try
            {
                //var car = Mapper.Map<CarDamaged>(model);
                car.DateAuctionStart = DateTime.Now;
                if (!Repo.Create(car))
                {
                    ModelState.AddModelError("", "Error during creating...");
                    return View(car);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(car);
            }
        }

        // GET: CarDamagedController/Edit/5
        public ActionResult Edit(int id)
        {
            var car = Repo.FindById(id);
            if (car == null)
                return NotFound();
            return View(car);
        }

        // POST: CarDamagedController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CarDamaged model)
        {
            try
            {
                var isSuccess = Repo.Update(model);
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
        // GET: CarDamagedController/Delete/5
        public ActionResult Delete(int id)
        {
            var car = Repo.FindById(id);
            if (car == null)
                return NotFound();
            return View(car);
        }

        // POST: CarDamagedController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CarDamaged model)
        {
            try
            {
                var isSuccess = Repo.Delete(model);
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
