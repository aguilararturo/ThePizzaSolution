using Data.Models;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repository
{
    public class ToppingRepository : GenericRepository<Topping>, IToppingRepository
    {
        public ToppingRepository(ThePizzaDBContext context) : base(context)
        {
        }
    }
}
