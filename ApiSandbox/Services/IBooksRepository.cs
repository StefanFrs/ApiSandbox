using ApiSandbox.Models;
using System.Collections.Generic;

namespace ApiSandbox.Services
{
    public interface IBooksRepository
    {
        void DeleteBook(int id);

        Book GetBook(int id);

        void AddBook(Book value);

        void UpdateBook(int id, Book value);

        IEnumerable<Book> GetBooks();
    }
}