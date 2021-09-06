using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DoNotFret.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AuthDemo.Auth.Models;
using Microsoft.AspNetCore.Identity;
using DoNotFret.Pages;

namespace DoNotFret.Data
{
    public class DoNotFretDbContext : IdentityDbContext<AuthUser> 
    {
        public DbSet<Instrument> Instrument { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Category> Category { get; set; }

        // Nav Properties
        public DbSet<CartItem> CartItem { get; set; }

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
                    InstrumentType = "Guitar",
                    Brand = "Ibanez",
                    Material = "Basswood",
                    Description = "Natural Wood Finish, 6 string electric guitar",
                },

                new Instrument
                {
                    Id = 2,
                    InstrumentType = "Bass",
                    Brand = "Rickenbacker",
                    Material = "Eastern hardrock Maple",
                    Description = "Cherry Red, 4 string electric bass",
                });

            modelBuilder.Entity<Cart>().HasData(
                new Cart
                {
                    Id = 1,
                    UserId = "1",
                });

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Pianos",
                },
                new Category
                {
                    Id = 2,
                    Name = "Basses",
                }
                );

            modelBuilder.Entity<CartItem>().HasKey(
                cartItem => new { cartItem.CartId, cartItem.InstrumentId }
            );

            // Creating our roles that we will assign users.
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "admin", Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = Guid.Empty.ToString() },
                new IdentityRole { Id = "technician", Name = "Technician", NormalizedName = "TECHNICIAN", ConcurrencyStamp = Guid.Empty.ToString() },
                new IdentityRole { Id = "user", Name = "User", NormalizedName = "USER", ConcurrencyStamp = Guid.Empty.ToString() }
                );
        }
    }
}
