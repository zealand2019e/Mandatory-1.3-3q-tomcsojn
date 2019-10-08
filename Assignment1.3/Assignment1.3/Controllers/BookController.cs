using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1._3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {


        static List<Book> books = new List<Book>()
        {
            new Book("The Hobbit",". R. R. Tolkien",340,"2348573648576"),
            new Book("The Da Vinci Code","Dan Brown",200,"7656463756765"),
            new Book("The Hunger Games","Suzanne Collins",123,"5748395776566"),
            new Book("Romeo and Juliet","William Shaekspeare",55,"4444568965985")
        };
        // GET api/Book
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            return books;
        }

        // GET api/Book/5
        [HttpGet("{id}")]
        public ActionResult<Book> Get(string id)
        {
            return books.Find(e => e.Isbn13 == id);
        }

        // POST api/Book
        [HttpPost]
        public void Post([FromBody] Book newbook)
        {
            books.Add(newbook);
        }

        // PUT api/Book/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Book newbook)
        {
            //what may look stupid but works is not stupid!
            Delete(id);
            Post(newbook);
        }

        // DELETE api/Book/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            books.RemoveAll(e => e.Isbn13 == id);
        }
    }
}
