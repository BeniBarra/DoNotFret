using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DoNotFret.Models;

namespace DoNotFret.Data
{
    public class DoNotFretDbContext : DbContext 
    {
        public DbSet<StringInstrument> StringInstrument { get; set; }
        public DbSet<WindInstrument> WindInstrument { get; set; }

        //constructor
        public DoNotFretDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
