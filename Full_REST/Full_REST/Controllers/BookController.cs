﻿namespace Full_REST.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using BookDb;

    public class BooksController : ApiController
    {
        private BooksEntities db = new BooksEntities();
        // GET api/books
        public IEnumerable<Book> GetAllBooks()
        {
            var result = db.Books;
            return result;
        }

        // GET api/book/{id}
        public IHttpActionResult GetBookById(int id)
        {
            var book = db.Books.FindAsync(id).Result;
            if (book != null) return Ok(book);
            return BadRequest("No matches..!!");
        }
        // GET api/books/{author}
        public IHttpActionResult GetBookByAuthor(string author)
        {
            var book = db.Books.FindAsync(author).Result;
            if(ReferenceEquals(book,null)) return BadRequest("No such author detected..!!");
            return Ok(book);
        }
    }
}