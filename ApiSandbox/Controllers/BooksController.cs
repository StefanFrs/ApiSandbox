// <copyright file="BooksController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using ApiSandbox.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace ApiSandbox.Controllers
{
    /// <summary>
    ///   <br />
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService booksService;

        public BooksController(IBooksService booksService)
        {
            this.booksService = booksService;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return this.booksService.Get();
        }

        // GET api/<BooksController>/5

        /// <summary>Gets the specified book by id.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>book object.</returns>
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                return this.Ok(this.booksService.Get(id));
            }
            catch (Exception e)
            {
                return this.NotFound();
            }
        }

        // POST api/<BooksController>
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            this.booksService.Post(value);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book value)
        {
            this.booksService.Put(id, value);
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.booksService.Delete(id);
        }
    }
}
