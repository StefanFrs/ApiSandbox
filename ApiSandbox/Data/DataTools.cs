using ApiSandbox.Models;
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
                    Console.WriteLine("No books!");
                    var book = new Book();
                    var book2 = new Book();
                    book.Author = "Autor1";
                    book.Id = 1;
                    book.Title = "Title1";
                    book.Language = "Eng";
                    book2.Author = "Autor2";
                    book2.Id = 2;
                    book2.Title = "Title2";
                    book2.Language = "RO";
                    applicationDbContext.Add(book);
                    applicationDbContext.Add(book2);
                    applicationDbContext.SaveChanges();
                }
            }
         }
      }
}
