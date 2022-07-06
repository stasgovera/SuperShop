﻿using SuperShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        private Random _random;

        public SeedDb(DataContext context)
        {
            _context = context;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            if (!_context.Products.Any())
            {
                AddProduct("Huawei P40");
                AddProduct("Iphone 11");
                AddProduct("SmartWatch Mi60");
                AddProduct("Xbox Controller");
            }
            await _context.SaveChangesAsync();
        }

        private void AddProduct(string name)
        {
            _context.Products.Add(new Product
            {
                Name = name ,
                Price = _random.Next(1000) ,
                IsAvailable = true ,
                Stock = _random.Next(100)
            });
        }
    }
}
