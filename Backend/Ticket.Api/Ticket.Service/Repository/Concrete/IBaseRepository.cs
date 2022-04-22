using System.Collections.Generic;

namespace Ticket.Service.Repository
{
    public interface IBaseRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        bool Create(T model);
        bool Edit(T model);
        bool Delete(T model);
        bool Delete(int id);
        void Save();
    }
}
