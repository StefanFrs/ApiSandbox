using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSandbox;
using ApiSandbox.Data;
using ApiSandbox.Models;

namespace ApiSandbox.Services
{
    public class DbBookRepository : IBooksRepository
    {
        private readonly ApplicationDbContext context;

        public DbBookRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void AddBook(Book book)
        {
            this.context.Add(book);
            this.context.SaveChangesAsync();
        }

        public void DeleteBook(int id)
        {
            var book = this.context.Book.Find(id);
            this.context.Book.Remove(book);
            this.context.SaveChangesAsync();
        }

        public Book GetBook(int id)
        {
            var book = this.context.Book.FirstOrDefault(m => m.Id == id);
            return book;
        }

        public IEnumerable<Book> GetBooks()
        {
            return this.context.Book.ToList();
        }

        public void UpdateBook(int id, Book book)
        {
            this.context.Update(book);
            this.context.SaveChanges();
        }
    }
}