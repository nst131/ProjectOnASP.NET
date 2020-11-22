using DomainYandexMusic.Entities;

namespace DomainYandexMusic.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        int Count();

        void Create(T item);

        void Delete(T item);
    }
}
