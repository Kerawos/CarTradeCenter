using CarTradeCenter.Contracts;
using CarTradeCenter.Data;
using CarTradeCenter.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace CarTradeCenter.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IRepositoryVehicle RepoVehicle;
        private readonly IRepositoryImage RepoImg;
        public readonly int PageSizeArchivedDefault = 50;
        public readonly int PageSizeActiveDefault = 300;
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        

        public VehicleController(IRepositoryVehicle repoVehicle, IRepositoryImage repoImg, ApplicationDbContext db)
        {
            this.RepoVehicle = repoVehicle;
            this.RepoImg = repoImg;
        }


        [HttpGet]
        public ActionResult Index(string searchTerm, int pageNumber = 1)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            if (String.IsNullOrEmpty(searchTerm))
            {
                vehicles = RepoVehicle.FindAll();
            } 
            else
            {
                if (int.TryParse(searchTerm, out int auction))
                {
                    Vehicle vhcByID = RepoVehicle.FindById(auction);
                    if (vhcByID != null)
                        vehicles.Add(vhcByID); 
                }
                else
                {
                    vehicles = RepoVehicle.GetVehiclesByName(searchTerm);
                }
                
            }
            //RepoImg.UpdateAllImages(vehicles); //lazy loading
            return View(new PaginatedList<Vehicle>().CreateList(vehicles, pageNumber, PageSizeActiveDefault));
        }


        [HttpGet]
        public ActionResult IndexActive(string searchTerm, int pageNumber = 1)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            if (String.IsNullOrEmpty(searchTerm))
            {
                vehicles = RepoVehicle.FindAllActive();
            }
            else
            {
                if (int.TryParse(searchTerm, out int auction))
                {
                    Vehicle vhcByID = RepoVehicle.FindById(auction);
                    if (vhcByID != null)
                        vehicles.Add(vhcByID);
                }
                else
                {
                    vehicles = RepoVehicle.GetVehiclesByName(searchTerm, true);
                }

            }
            //RepoImg.UpdateAllImages(vehicles); //lazy loading
            return View(new PaginatedList<Vehicle>().CreateList(vehicles, pageNumber, PageSizeActiveDefault));
        }


        [HttpGet]
        public ActionResult IndexArchived(string searchTerm, int pageNumber = 1)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            if (String.IsNullOrEmpty(searchTerm))
            {
                vehicles = RepoVehicle.FindAllArchived();
            }
            else
            {
                if (int.TryParse(searchTerm, out int auction))
                {
                    Vehicle vhcByID = RepoVehicle.FindById(auction);
                    if (vhcByID != null)
                        vehicles.Add(vhcByID);
                }
                else
                {
                    vehicles = RepoVehicle.GetVehiclesByName(searchTerm, false);
                }
            }
            return View(new PaginatedList<Vehicle>().CreateList(vehicles, pageNumber, PageSizeArchivedDefault));
        }


        // GET: VehicleController/Details/id
        public ActionResult Details(int id)
        {
            Vehicle vhc = RepoVehicle.FindById(id);
            if (vhc == null)
                return NotFound();
            return View(vhc);
        }
 
    }
}
