using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CarTradeCenter.Models;

namespace CarTradeCenter.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarDamaged> CarsDamaged { get; set; }
        //public DbSet<CarTradeCenter.Models.CarDamagedViewModel> CarDamagedViewModel { get; set; }
    }
}
