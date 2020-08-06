using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Helper
{
    public class ResponseStatus
    {
        public bool Success
        {
            get;
            internal set;
        }

        public bool Cancelled
        {
            get;
            internal set;
        }

        public string Error
        {
            get;
            internal set;
        }
    }
}
