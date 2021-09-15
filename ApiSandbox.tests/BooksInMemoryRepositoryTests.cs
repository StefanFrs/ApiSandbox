using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiSandbox;
using ApiSandbox.Controllers;
using System.IO;
using Xunit;
using ApiSandbox.Models;
using ApiSandbox.Services;

namespace ApiSandbox.tests
{
    public class BooksInMemoryRepositoryTests
    {
        [Fact]
        public static void ShouldHaveLondonCoordinates()
        {
            // Assume
            var booksService = new BooksInMemoryRepository();

            // Act
            booksService.Post(new Book
            {
                Title = "Psyho ABC",
                Author = "John",
                Language = "Romanian",
            });

            booksService.Delete(2);
            booksService.Post(new Book
            {
                Title = "The art of not giving a f..",
                Author = "Tom example",
                Language = "English",
            });

            // Assert
            Assert.Equal("Psyho ABC", booksService.Get(3).Title);
        }
    }
}
