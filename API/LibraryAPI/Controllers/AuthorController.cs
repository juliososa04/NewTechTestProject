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
    public class AuthorController : ApiController
    {
        // GET: api/Author
        public HttpResponseMessage Get()
        {
            var Books = AuthorBLL.GetAuthors();
            if (Books == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Books);
        }
        [Route("api/Author/GetByBook/")]
        public HttpResponseMessage GetByBook(int id)
        {
            var Authors = AuthorBLL.GetAuhtorsByBooks(id);
            if (Authors == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, id);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Authors);
        }

        // GET: api/Author/5
        public HttpResponseMessage Get(int id)
        {
            var Author = AuthorBLL.GetAutorBy(id);
            if (Author == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, id);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Author);
        }

        // POST: api/Author
        public HttpResponseMessage Post([FromBody]AuthorEntity entity)
        {
            var author = AuthorBLL.CreateAuthor(entity);
            if (author == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.Created, author);
        }

        // PUT: api/Author/5
        public HttpResponseMessage Put(int id, [FromBody]AuthorEntity entity)
        {
            var author = AuthorBLL.UpdateAuthor(id,entity);
            if (author == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.Created, author);
        }

        // DELETE: api/Author/5
        public HttpResponseMessage Delete(int id)
        {

            if (!AuthorBLL.DeleteAuthor(id))
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
