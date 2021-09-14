using ApiSandbox.Models;
using System.Collections.Generic;

namespace ApiSandbox
{
    public interface IBooksRepository
    {
        void Delete(int id);

        IEnumerable<Book> Get();

        Book Get(int id);

        void Post(Book value);

        void Put(int id, Book value);
    }
}