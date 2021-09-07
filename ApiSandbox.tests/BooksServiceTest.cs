using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSandbox.tests
{
    class BooksServiceTest
    {
        public void ShouldHaveLondonCoordinates()
        {
            // Assume
            var booksService = new BooksService();
          

            // Act
           booksService.Post(new Book
           
            {
                Id = 1,
                Title = "Psyho ABC",
                Author = "John",
                Language = "Romanian"
            });

            booksService.Service.Delete(2);
            booksService.Post(new Book
            {
                Id = 2,
                Title = "The art of not giving a f..",
                Author = "Tom example",
                Language = "English"
            });

            Assert.Equal("syho ABC", booksService.Get(3).Test);


        }
    }
}
