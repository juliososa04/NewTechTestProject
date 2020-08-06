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
    /// Entity Model for book
    /// </summary>
    public class BookEntity
    {
        #region Definitions
        public  int ID { get; set; }
        public  int PageCount { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Excerpt { get; set; }
        public DateTime PublishDate { get; set; }
        #endregion
    }
}
