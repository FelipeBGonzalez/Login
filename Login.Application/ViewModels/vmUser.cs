using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Login.Application.ViewModels
{
    [Serializable]
    [DataContract]
    public class vmUser
    {
        public vmUser()
        {
            phones = new List<vmPhone>();
        }
        [DataMember]
        public string firstName { get; set; }
        [DataMember]
        public string lastName { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public string password { get; set; }
        [DataMember]
        public List<vmPhone> phones { get; set; }
        [DataMember]
        public string token { get; set; }
        [DataMember]
        public DateTime? create_ate { get; set; }
        [DataMember]
        public DateTime? last_login { get; set; }
    }
}
