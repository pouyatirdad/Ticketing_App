using System;
using System.Collections.Generic;
using System.Linq;
using Ticket.Data.Context;
using Ticket.Service.Repository.Abstract;

namespace Ticket.Service.Repository.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly MyDbContext context;
        public BaseRepository(MyDbContext context)
        {
            this.context = context;
        }
        public bool Create(T model)
        {
            try
            {
                context.Set<T>().Add(model);
                Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(T model)
        {
            try
            {
                context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            var finded = GetById(id);
            return Delete(finded);
        }

        public bool Edit(T model)
        {
            try
            {
                context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
