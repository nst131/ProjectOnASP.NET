using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainYandexMusic.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        int Count();

        void Create(T item);

        void Delete(T item);

        T Get(object id);
    }
}
