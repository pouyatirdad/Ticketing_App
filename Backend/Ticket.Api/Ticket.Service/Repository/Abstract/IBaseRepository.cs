﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Service.Repository.Abstract
{
    public interface IBaseRepository<T> where T : class,new()
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        bool Create<dto>(dto model);
        bool Edit(T model);
        bool Delete(T model);
        bool Delete(int id);
        void Save();
    }
}
