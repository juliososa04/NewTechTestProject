using LibraryAPI.Entities;
using LibraryAPI.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryAPI.BLL
{
    /// <summary>
    /// Author:Julio Sosa
    /// Date:8/5/2020
    /// Managing Book Request  
    /// </summary>
    public static class BookBLL
    {
        #region Definitions
        private static string BaseUrl = Settings.BaseUrl;
        private static CancellationToken cancellationToken;
        #endregion

        #region Pulbic Methods
        /// <summary>
        ///  Get all Books 
        /// </summary>
        /// <returns></returns>
        public static List<BookEntity> GetBooks()
        {
            var result = new List<BookEntity>();

            var rep=ApiClient.GetAsync(BaseUrl, "/api/Books", null, cancellationToken);

            if (rep.Result.Success)
            {
                result = JsonConvert.DeserializeObject<List<BookEntity>>(rep.Result.Content);
            }

            return result;
        }
        /// <summary>
        /// Get Book by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static BookEntity GetBookBy(int id)
        {
            var result = new BookEntity();

            var parameters = new Dictionary<string, string>();
            parameters.Add("id",id.ToString());

            var rep = ApiClient.GetAsync(BaseUrl, "/api/Books", parameters, cancellationToken);

            if (rep.Result.Success)
            {
                result = JsonConvert.DeserializeObject<BookEntity>(rep.Result.Content);
            }

            return result;
        }
        /// <summary>
        /// Create Book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public  static BookEntity CreateBook(BookEntity book)
        {
            var rep = ApiClient.PostAsync(BaseUrl, "/api/Books",null,book, cancellationToken);
            var result = new BookEntity();
            if (rep.Result.Success)
            {
                result = JsonConvert.DeserializeObject<BookEntity>(rep.Result.Content);
            }

            return result;
        }
        /// <summary>
        /// Update Book
        /// </summary>
        /// <param name="id"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        public static BookEntity UpdateBook(int id,BookEntity book)
        {
            var rep = ApiClient.PutAsync(BaseUrl, "/api/Books/"+id, null, book, cancellationToken);
            var result = new BookEntity();
            if (rep.Result.Success)
            {
                result = JsonConvert.DeserializeObject<BookEntity>(rep.Result.Content);
            }

            return result;
        }
        /// <summary>
        /// Delete Book
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteBook(int id)
        {
            var rep = ApiClient.DeleteAsync(BaseUrl, "/api/Books/"+id , null, null, cancellationToken);
            var result = new BookEntity();
            return rep.Result.Success;
        }
        #endregion

    }
}
