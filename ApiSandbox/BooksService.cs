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
            this.books = new List<Book>();
            this.books.Add(new Book
            {
                Id = 1,
                Title = "Psyho ABC",
                Author = "John",
                Language = "Romanian",
            });

            this.books.Add(new Book
            {
                Id = 2,
                Title = "The art of not giving a f..",
                Author = "Tom example",
                Language = "English",
            });

        }

        public IEnumerable<Book> Get()
        {
            return this.books;
        }

        public Book Get(int id)
        {
            return this.books.Single(_ => _.Id == id);
        }

        public void Post(Book value)
        {
            int id = CountMemory.GetNewId();
            value.Id = id;
            this.books.Add(value);
        }

        // PUT api/<BooksController>/5
        public void Put(int id, Book value)
        {
            var index = this.books.FindIndex(book => book.Id == id);
            this.books[index] = value;
        }

        // DELETE api/<BooksController>/5

        public void Delete(int id)
        {
            this.books.Remove(Get(id));
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
