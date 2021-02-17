using System;
using System.Collections.Generic;

namespace Login.Domain.Models
{
    public class ErrorDomain
    {
        public string message { get; set; }
        public int errorCode { get; set; }        
    }
}
