﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiSandbox.Models;
using ApiSandbox.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using ApiSandbox.DTOs;
using AutoMapper;
using ApiSandbox;

namespace ApiSandbox.Controllers
{
    /// <summary>
    ///   <br />
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository repository;
        private readonly IHubContext<MessageHub> hubContext;
        private readonly IMapper mapper;

        public BooksController(IBooksRepository repository, IHubContext<MessageHub> hubContext, IMapper mapper)
        {
            this.repository = repository;
            this.hubContext = hubContext;
            this.mapper = mapper;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var bookList = repository.GetBooks();
            var readBookList = mapper.Map<IEnumerable<ReadBookDto>>(bookList);
            return Ok(readBookList);
        }

        // GET api/<BooksController>/5

        /// <summary>Gets the specified book by id.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ReadBookDto object.</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Book book = repository.GetBook(id);
                ReadBookDto readBookDto = mapper.Map<ReadBookDto>(book);
                return Ok(readBookDto);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // POST api/<BooksController>

        /// <summary>
        /// Adds a new Book object.
        /// </summary>
        /// <param name="bookDto">The value.</param>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBookDto bookDto)
        {
            if (ModelState.IsValid)
            {
                Book book = mapper.Map<Book>(bookDto);
                repository.AddBook(book);
                await hubContext.Clients.All.SendAsync("AddedBook", book);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/<BooksController>/5

        /// <summary>
        /// Updates a Book object by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="bookDto">The value.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] CreateBookDto bookDto)
        {
            Book book = mapper.Map<Book>(bookDto);
            repository.UpdateBook(id, book);
            await hubContext.Clients.All.SendAsync("EditedBook", book);
            return Ok();
        }

        // DELETE api/<BooksController>/5

        /// <summary>
        /// Deletes a Book object by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Book book = repository.GetBook(id);
            hubContext.Clients.All.SendAsync("DeletedBook", book);
            repository.DeleteBook(id); 
            return Ok();
        }
    }
}