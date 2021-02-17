using System;
using System.Collections.Generic;

namespace Login.Domain.Models
{
    public class PhoneDomain
    {
        public int number { get; set; }
        public int area_code { get; set; }
        public string country_code { get; set; }
        public string id { get; set; }
    }
}
