using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }

        public List<ProductTopping> ProductToppings { get; set; }
    }
}
