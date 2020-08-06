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
    /// Managing Author Request  
    /// </summary>
    public static class AuthorBLL
    {
        #region Definitions
        private static string BaseUrl = Settings.BaseUrl;
        private static CancellationToken cancellationToken;
        #endregion

        #region Pulbic Methods
        /// <summary>
        ///  Get all Authors 
        /// </summary>
        /// <returns></returns>
        public static List<AuthorEntity> GetAuthors()
        {
            var result = new List<AuthorEntity>();

            var rep = ApiClient.GetAsync(BaseUrl, "/api/Authors", null, cancellationToken);

            if (rep.Result.Success)
            {
                result = JsonConvert.DeserializeObject<List<AuthorEntity>>(rep.Result.Content);
            }
            return result;
        }
      
        /// <summary>
        ///  Get all auhors by Book 
        /// </summary>
        /// <returns></returns>
        public static List<AuthorEntity> GetAuhtorsByBooks(int Bookid)
        {
            List<AuthorEntity> result = new List<AuthorEntity>();
            var parameters = new Dictionary<string, string>();
            parameters.Add("idBook", Bookid.ToString());
            var rep=ApiClient.GetAsync(BaseUrl, "/authors/books/"+Bookid,null, cancellationToken);

            if (rep.Result.Success)
            {
                result = JsonConvert.DeserializeObject<List<AuthorEntity>>(rep.Result.Content);
               // return result;
            }

            return result;
        }
        /// <summary>
        /// Get Author by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static AuthorEntity GetAutorBy(int id)
        {
            var result = new AuthorEntity();

            var parameters = new Dictionary<string, string>();
            parameters.Add("id",id.ToString());

            var rep = ApiClient.GetAsync(BaseUrl, "/api/Authors", parameters, cancellationToken);

            if (rep.Result.Success)
            {
                result = JsonConvert.DeserializeObject<AuthorEntity>(rep.Result.Content);
            }

            return result;
        }
        public static AuthorEntity  CreateAuthor(AuthorEntity entity)
        {
            var result = new AuthorEntity();

         

            var rep = ApiClient.PostAsync(BaseUrl, "/api/Authors/", null,entity, cancellationToken);

            if (rep.Result.Success)
            {
                result = JsonConvert.DeserializeObject<AuthorEntity>(rep.Result.Content);
            }

            return result;
        }
        public static AuthorEntity UpdateAuthor(int id,AuthorEntity entity)
        {
            var result = new AuthorEntity();

            var rep = ApiClient.PutAsync(BaseUrl, "/api/Authors/"+id, null, entity, cancellationToken);

            if (rep.Result.Success)
            {
                result = JsonConvert.DeserializeObject<AuthorEntity>(rep.Result.Content);
            }

            return result;

        }
        /// <summary>
        /// Delete Authors
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteAuthor(int id)
        {
            var rep = ApiClient.DeleteAsync(BaseUrl, "/api/Authors/" + id, null, null, cancellationToken);
            return rep.Result.Success;
        }
        #endregion

    }
}
