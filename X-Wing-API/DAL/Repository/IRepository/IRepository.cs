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
        void Create(T entity);
        void Update(TKey id, T entity);
        void Delete(TKey id);
    }
}
