using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Contracts
{
    public interface IProductRepository:IRepository<Product>
    {
        Product GetByIdWithToppings(int id);
        IEnumerable<Product> GetAllWithToppings();
    }
}
