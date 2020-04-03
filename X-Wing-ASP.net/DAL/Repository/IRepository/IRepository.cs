using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IRepository<TKey, T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetOne(TKey id);
        bool Create(T entity);
        bool Update(TKey id, T entity);
        void Delete(TKey id, T T);
    }
}
