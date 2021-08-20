using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DoNotFret.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AuthDemo.Auth.Models;
using Microsoft.AspNetCore.Identity;

namespace DoNotFret.Data
{
    public class DoNotFretDbContext : IdentityDbContext<AuthUser> 
    {
        public DbSet<Instrument> Instrument { get; set; }

        //constructor for out DbContext. Inserting options.
        public DoNotFretDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Instrument>().HasData(
                new Instrument
                { 
                    Id = 1, 
                    Name = "Guitar", 
                    Brand = "Ibanez", 
                    Material = "Basswood", 
                    Description = "Natural Wood Finish, 6 string electric guitar",
                    InstrumentType = InstrumentType.String
                });

            modelBuilder.Entity<Instrument>().HasData(
                new Instrument
                {
                    Id = 2,
                    Name = "Bass",
                    Brand = "Rickenbacker",
                    Material = "Eastern hardrock Maple",
                    Description = "Cherry Red, 4 string electric bass",
                    InstrumentType = InstrumentType.String
                });

            // Creating our roles that we will assign users.
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "admin", Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = Guid.Empty.ToString() },
                new IdentityRole { Id = "technician", Name = "Technician", NormalizedName = "TECHNICIAN", ConcurrencyStamp = Guid.Empty.ToString() },
                new IdentityRole { Id = "user", Name = "User", NormalizedName = "USER", ConcurrencyStamp = Guid.Empty.ToString() }
                );
        }
    }
}
