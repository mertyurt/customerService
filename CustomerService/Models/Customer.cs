using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CustomerService.Models
{
    public class Customer
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Nationality { get; set; }

        [DataMember]
        public byte Status { get; set; }
        //0: "Taken for processing", 1: "Qualified", 2: "Out of scope"
    }
}