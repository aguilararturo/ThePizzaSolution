using Data.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
   public class GenericRepository<T> : IRepository<T> where T:class
    {
        private readonly ThePizzaDBContext _dBContext;
        private readonly DbSet<T> _dBSet;

        public GenericRepository(ThePizzaDBContext context)
        {
            this._dBContext = context;
            this._dBSet = _dBContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dBSet.Add(entity);            
        }

        public void Delete(T entity)
        {
            this._dBSet.Remove(entity);            
        }        

        public IEnumerable<T> GetAll()
        {
            return this._dBSet.ToList();            
        }

        public T GetByID(int id)
        {
            var data  = _dBSet.Find(id);
            
            return data;
        }

        public void Update(T entity)
        {
            _dBSet.Attach(entity);
            _dBContext.Entry(entity).State = EntityState.Modified;            
        }
    }
}
