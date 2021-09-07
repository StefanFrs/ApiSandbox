﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiSandbox
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static List<Book> books;
        static BooksController()
        {
            books = new List<Book>();
            books.Add ( new Book
            {
                Id = 1,
                Title = "Psyho ABC",
                Author = "John",
                Language = "Romanian"
            });

            books.Add ( new Book
            {
                Id = 2,
                Title = "The art of not giving a f..",
                Author = "Tom example",
                Language = "English"
            });

        }
        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return books;
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return books.Single(book=> book.Id == id);
        }

     
        // POST api/<BooksController>
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            int id = books.Count + 1;
            value.Id = id;
            books.Add(value);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
