using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Helper
{
    public class ResponseContent : ResponseStatus
    {
        public string Content
        {
            get;
            internal set;
        }
    }
}
