using System;
using System.Collections.Generic;

namespace Login.Domain.Models
{
    public class UserDomain
    {
        public UserDomain()
        {
            phones = new List<PhoneDomain>();
        }        
        public string firstName { get; set; }
        
        public string lastName { get; set; }
        
        public string email { get; set; }
        
        public string password { get; set; }
        public string id { get; set; }
        public string token { get; set; }
        public List<PhoneDomain> phones { get; set; }
        public DateTime create_ate { get; set; }
        public DateTime? last_login { get; set; }
    }
}
