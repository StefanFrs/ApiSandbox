using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSandbox.Models;
using ApiSandbox.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiSandbox.DTOs;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace ApiSandbox.Controllers
{
    /// <summary>BooksController .
    /// Exposes api CRUD operations for books.</summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;

        /// <summary>Initializes a new instance of the <see cref="BooksController" /> class.</summary>
        public BooksController(ApplicationDbContext context, IMapper mapper)
        {
            
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/<ValuesController>

        /// <summary>Gets all the instances of books.</summary>
        /// <returns>Enumerable of book objects.<br /></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Book.ToListAsync());
        }

        // GET api/<ValuesController>/5

        /// <summary>Gets the specified book by id.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>book object.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var book = await _context.Book
                .FirstOrDefaultAsync(m => m.Id == id);
                return Ok(book);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // POST api/<ValuesController>

        /// <summary>Posts the specified book.</summary>
        /// <param name="bookDto">The value.</param>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBookDto bookDto)
        {
            if (ModelState.IsValid)
            {
                Book book = mapper.Map<Book>(bookDto);
                _context.Add(book);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/<ValuesController>/

        /// <summary>Updates the book at the specified id with the fields of value.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="book">The value.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Book book)
        {
            _context.Update(book);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<ValuesController>/5

        /// <summary>Deletes the book found at the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _context.Book.FindAsync(id);
            _context.Book.Remove(book);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}