using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CustomerService.Models
{
    public class ReqCreateCustomer
    {
        [DataMember]
        public string Nationality { get; set; }

        [DataMember]
        public byte Status { get; set; }
    }
}