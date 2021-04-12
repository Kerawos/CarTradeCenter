using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CarTradeCenter.Models;
using CarTradeCenter.Data.Models;

namespace CarTradeCenter.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Vehicle>()
                   .HasMany<Image>(v => v.Images)
                   .WithOne(i => i.Vehicle)
                   .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(builder);
        }
    }
}
