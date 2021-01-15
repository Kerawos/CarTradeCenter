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
            return View();
        }

        // GET: CarDamagedController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarDamagedController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarDamagedController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CarDamagedController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarDamagedController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CarDamagedController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
