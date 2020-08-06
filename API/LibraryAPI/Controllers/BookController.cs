using LibraryAPI.BLL;
using LibraryAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibraryAPI.Controllers
{
    public class BookController : ApiController
    {
        // GET: api/Book
        public HttpResponseMessage Get()
        {
            var Books = BookBLL.GetBooks();
            if (Books == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Books);
        }

        // GET: api/Book/5
        public HttpResponseMessage Get(int id)
        {
            var Books = BookBLL.GetBookBy(id);
            if (Books == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound,id);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Books);
        }

        // POST: api/Book
        public HttpResponseMessage Post([FromBody]BookEntity bookentity)
        {
            var Book = BookBLL.CreateBook(bookentity);
            if (Book == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.Created,Book);
        }

        // PUT: api/Book/5
        public HttpResponseMessage Put(int id, [FromBody]BookEntity bookentity)
        {
            var Book = BookBLL.UpdateBook(id, bookentity);
            if (Book == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Book);
        }

        // DELETE: api/Book/5
        public HttpResponseMessage Delete(int id)
        {
            
            if (!BookBLL.DeleteBook(id))
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
