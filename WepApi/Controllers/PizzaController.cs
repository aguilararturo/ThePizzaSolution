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
    [Route("api/Pizza")]
    public class PizzaController : Controller
    {
        private IRepositoryWrapper _repoWrapper;

        public PizzaController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
        
        // GET: api/Pizza
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var results = _repoWrapper.Product.GetAllWithToppings()
            ;

            List<Product> response = new List<Product>();

            foreach (var item in results)
            {
                foreach (var top in item.ProductToppings)
                {
                    top.Product = null;
                }

                response.Add(item);
            }

            return results;
        }

        // GET: api/Pizza/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var prod = _repoWrapper.Product.GetByID(id);
            return prod;
        }
        
        // POST: api/Pizza
        [HttpPost]
        public void Post([FromBody]Product value)
        {
            _repoWrapper.Product.Add(value);
            _repoWrapper.Save();
        }
        
        // PUT: api/Pizza/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Product value)
        {
            var prod = _repoWrapper.Product.GetByID(id);
            prod.Name = value.Name;
            prod.ProductToppings = value.ProductToppings;

            _repoWrapper.Product.Update(prod);
            _repoWrapper.Save();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var toDel = _repoWrapper.Product.GetByID(id);
            _repoWrapper.Product.Delete(toDel);
            _repoWrapper.Save();
        }        

    }
}
