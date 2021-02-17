using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Login.Application.ViewModels
{
    [Serializable]
    [DataContract]
    public class vmPhone
    {
        [DataMember]
        public int number { get; set; }
        [DataMember]
        public int area_code { get; set; }
        [DataMember]
        public string country_code { get; set; }
    }
}
