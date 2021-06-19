using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Errors
{
    public class ApiExceptions  
    {
        public ApiExceptions(int statuscode,string messages =null, string details = null)
        {
            StatusCode = statuscode;
            Messages = messages;
            Details = details;
        }
        public int StatusCode { get; set; }

        public string Messages { get; set; }

        public string Details { get; set; }
    }
}
