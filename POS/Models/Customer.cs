using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public int CustomerFrameId { get; set; }
        public string CustomerFrameName { get; set; }
        public string CustomerFullName { get; set; }
    }
}