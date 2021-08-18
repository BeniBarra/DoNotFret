using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DoNotFret.Models;

namespace DoNotFret.Data
{
    public class DoNotFretDbContext : DbContext 
    {
        public DbSet<Instruments> Instrument { get; set; }

        //constructor
        public DoNotFretDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Instruments>().HasData(
                new Instruments
                { 
                    Id = 1, 
                    Name = "Guitar", 
                    Brand = "Ibanez", 
                    Material = "Basswood", 
                    Description = "Natural Wood Finish, 6 string electric guitar",
                    InstrumentType = InstrumentType.String
                });

            modelBuilder.Entity<Instruments>().HasData(
                new Instruments
                {
                    Id = 2,
                    Name = "Bass",
                    Brand = "Rickenbacker",
                    Material = "Eastern hardrock Maple",
                    Description = "Cherry Red, 4 string electric bass",
                    InstrumentType = InstrumentType.String
                });

        }
    }
}
