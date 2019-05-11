using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Contracts
{
   public interface IRepositoryWrapper
    {
        IProductRepository Product { get; }
        IToppingRepository Topping { get; }
        void Save();
    }
}
