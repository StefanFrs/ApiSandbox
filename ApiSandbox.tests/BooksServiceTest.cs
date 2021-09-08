using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetSandbox;
using AspNetSandbox.Controllers;
using System.IO;
using Xunit;

namespace ApiSandbox.tests
{
    public class BooksServiceTest
    {
        [Fact]
        public static void ShouldHaveLondonCoordinates()
        {
            // Assume
            var booksService = new BooksService();

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
