using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Contracts;

namespace ThePizzaSolution.Controllers
{
    [Produces("application/json")]
    [Route("api/Topping")]
    public class ToppingController : Controller
    {
        private IRepositoryWrapper _repoWrapper;

        public ToppingController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
        // GET: api/Topping
        [HttpGet]
        public IEnumerable<Topping> Get()
        {
            return _repoWrapper.Topping.GetAll();
        }

        // GET: api/Topping/5
        [HttpGet("{id}")]
        public Topping Get(int id)
        {
            var value = _repoWrapper.Topping.GetByID(id);
            return value;
        }
        
        // POST: api/Topping
        [HttpPost]
        public void Post([FromBody]Topping value)
        {
            _repoWrapper.Topping.Add(value);
            _repoWrapper.Save();
        }
        
        // PUT: api/Topping/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Topping value)
        {
            var prod = _repoWrapper.Topping.GetByID(id);
            prod.Name = value.Name;
            prod.ProductToppings = value.ProductToppings;

            _repoWrapper.Topping.Update(prod);
            _repoWrapper.Save();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var toDel = _repoWrapper.Topping.GetByID(id);
            _repoWrapper.Topping.Delete(toDel);
            _repoWrapper.Save();
        }

        [HttpGet("GetToppingsForPizza")]
        public IEnumerable<Topping> GetToppingsForPizza(int pizzaId)
        {
            var pizza =_repoWrapper.Product.GetByID(pizzaId);
            return pizza.ProductToppings.Select(s => s.Topping);
        }

        [HttpPost("AddToppingToPizza")]
        public void AddToppingToPizza(int toppingId, int pizzaId)
        {
            var pizza = _repoWrapper.Product.GetByID(pizzaId);
            var topping = _repoWrapper.Topping.GetByID(toppingId);

            pizza.ProductToppings.Add(new ProductTopping() { ProductID = pizzaId, Product = pizza, Topping = topping });

            _repoWrapper.Save();
        }
    }
}
