using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Login.Application.ViewModels
{
    [Serializable]
    [DataContract]
    public class vmError
    {
        [DataMember]
        public string message { get; set; }
        [DataMember]
        public int errorCode { get; set; }
    }
}
