﻿using JhooneByUju.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JhooneByUju.DataAccess.Data
{
    public class ApplicationDbContext: IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {                
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet <Product> Products { get; set; }   
        public DbSet <ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Hand Bags", DisplayOrder = 0 },
                new Category { Id = 2, Name = "Purses", DisplayOrder = 0 },
                new Category { Id = 3, Name = "Belts", DisplayOrder = 0 },
                new Category { Id = 4, Name = "Arts", DisplayOrder = 0 }
                );

            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "JG ALSP", StreetAddress = "9 Igbudu Market", City = "Warri", PhoneNumber = "08022347998", State = "Delta State", PostalCode = "WE 332" },
                 new Company { Id = 2, Name = "Market Square", StreetAddress = "300 Main Street", City = "Winnipeg", PhoneNumber = "4317839374", State = "Manitoba", PostalCode = "YSD 922" }

                );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Title = "Hand Bags 2", CategoryId = 1,ImageUrl = "",  StoreCode = 102, Designer = "Obianuju Igboayaka",Description= "Second Hand bag created by Igboayaka Uju", ListPrice= 14, Price = 13.2, Price15 = 11 },
                new Product { Id = 2, Title = "Hand Bag  1", CategoryId = 1, ImageUrl = "", StoreCode = 101, Designer = "Obianuju Igboayaka", Description = "First Hand bag created by Igboayaka Uju", ListPrice = 35, Price = 32, Price15 = 27 },
                new Product { Id = 3, Title = "Belts 1", CategoryId = 3, ImageUrl = "", StoreCode = 201, Designer = "Obianuju Igboayaka", Description = "First around the waist belt created by Igboayaka Uju", ListPrice = 27, Price = 25, Price15 = 22 },
                new Product { Id = 4, Title = "Arts 1", CategoryId = 4, ImageUrl = "", StoreCode = 301 , Designer = "Obianuju Igboayaka", Description = "First Art painting created by Igboayaka Uju", ListPrice = 200, Price = 187, Price15 = 160 }
                );
        }

        

    }
}
