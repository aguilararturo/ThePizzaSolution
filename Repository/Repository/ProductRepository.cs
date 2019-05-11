using Data.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private ThePizzaDBContext _context;
        public ProductRepository(ThePizzaDBContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllWithToppings()
        {
            var result = _context.Product.Include(a => a.ProductToppings).ThenInclude(t => t.Topping);            
            return result;
        }

        Product IProductRepository.GetByIdWithToppings(int id)
        {
            return _context.Product.Where(p => p.Id == id).Include(p => p.ProductToppings).FirstOrDefault();
        }
    }
}
