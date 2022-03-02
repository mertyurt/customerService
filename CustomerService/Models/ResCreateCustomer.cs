using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CustomerService.Models
{
    public class ResCreateCustomer
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Nationality { get; set; }

        [DataMember]
        public string Status { get; set; }
    }
}