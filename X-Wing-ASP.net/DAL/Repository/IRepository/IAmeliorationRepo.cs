using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IAmeliorationRepo<TKey, T> : IRepository<TKey, T> where T : class
    {
        T GetByName(string lastName);
    }
}
