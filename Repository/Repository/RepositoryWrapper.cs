using Data.Models;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {

        private ThePizzaDBContext _repoContext;
        private IProductRepository _product;
        private IToppingRepository _topping;

        public IProductRepository Product
        {
            get
            {
                if(_product == null)
                {
                    _product = new ProductRepository(_repoContext);
                }

                return _product;
            }
        }

        public IToppingRepository Topping
        {
            get
            {
                if (_topping == null)
                {
                    _topping = new ToppingRepository(_repoContext);
                }

                return _topping;
            }
        }

        public RepositoryWrapper(ThePizzaDBContext context)
        {
            _repoContext = context;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
