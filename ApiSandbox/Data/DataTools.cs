﻿using ApiSandbox.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSandbox.Data
{
    public static class DataTools
    {
        public static void SeedData(this IApplicationBuilder app) { 
         using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var applicationDbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                if (applicationDbContext.Book.Any())
                {
                    Console.WriteLine("The books are there!");
                }
                else
                {
                    var book = new Book();
                    applicationDbContext.Add(book);
                    var book2 = new Book();
                    applicationDbContext.Add(book2);
                    applicationDbContext.SaveChanges();
                }
            }
         }
      }
}
