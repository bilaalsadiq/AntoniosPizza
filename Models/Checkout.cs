using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AntoniosPizza.Models
{
    public class Checkout
    {
        public Cart cart { get; set; }
        public Order order { get; set; }
    }
}