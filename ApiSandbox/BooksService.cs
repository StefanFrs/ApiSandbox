using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSandbox
{
    public class BooksService : IBooksService
    {
        private List<Book> books;
        public BooksService()
        {
            books = new List<Book>();
            books.Add(new Book
            {
                Id = 1,
                Title = "Psyho ABC",
                Author = "John",
                Language = "Romanian"
            });

            books.Add(new Book
            {
                Id = 2,
                Title = "The art of not giving a f..",
                Author = "Tom example",
                Language = "English"
            });

        }

        public IEnumerable<Book> Get()
        {
            return books;
        }



        public Book Get(int id)
        {
            return books.Single(_ => _.Id == id);
        }


        public void Post(Book value)
        {
           
            int id = CountMemory.GetNewId();
            value.Id = id;
            books.Add(value);
        }

        // PUT api/<BooksController>/5

        public void Put(int id, Book value)
        {
            var index = books.FindIndex(book => book.Id == id);
            books[index] = value;
        }

        // DELETE api/<BooksController>/5

        public void Delete(int id)
        {
            books.Remove(Get(id));
        }
    }
    public static class CountMemory
    {
        public static int count = 2;

        internal static int GetNewId()
        {
            return ++count;
        }
    }
}
