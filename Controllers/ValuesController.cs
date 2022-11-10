using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooksWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DbData dbData;
        public ValuesController(DbData _dbData)
        {
            dbData = _dbData;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Books>> GetBooks()
        {
            return dbData.Books.ToList();
            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Books> GetBooksById(int id)
        {
            return dbData.Books.Where(i=>i.Id==id).FirstOrDefault();
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Books> Post([FromBody] Books value)
        {
            dbData.Books.Add(value);
            dbData.SaveChanges();
            return value;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Books> Put(int id, [FromBody] Books value)
        {
            var singleBook = dbData.Books.Where(i => i.Id == id).FirstOrDefault();
            if (singleBook != null)
            {
                singleBook.Name = value.Name;
                singleBook.AuthorName = value.AuthorName;
                dbData.Entry(singleBook).State = EntityState.Modified;
                dbData.SaveChanges();
            }
            else {
                return BadRequest();
            }
            return singleBook;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Books> Delete(int id)
        {
            var singleBook = dbData.Books.Where(i => i.Id == id).FirstOrDefault();
            if (singleBook != null)
            {
                dbData.Books.Remove(singleBook);
                dbData.SaveChanges();
            }
            else
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
