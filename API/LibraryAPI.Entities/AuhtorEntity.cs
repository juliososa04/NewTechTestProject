using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Entities
{
    /// <summary>
    /// Author:Julio Sosa
    /// Date:08-05-2020
    /// Entity Model for Author
    /// </summary>
    public class AuthorEntity
    {
        #region Definitions
        public  int ID { get; set; }
        public  int IDBook { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        #endregion
    }
}
