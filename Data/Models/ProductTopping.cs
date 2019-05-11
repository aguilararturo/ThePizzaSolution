using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class ProductTopping
    {
        public int ProductID { get; set; }
        public Product Product { get; set; }

        public int ToppingId { get; set; }
        public Topping Topping { get; set; }
    }
}
