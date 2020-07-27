using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.DAL.Repository.Intefaces
{
    public interface IGenericRepository<T> where T:class
    {
        T GetById(int Id);
        T GetFirstOrDefault(Expression<Func<T, bool>> predicate);
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();

        void Add(T entity);
        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void RemoveById(int Id);

        void Update(T entity);
        void UpdateRAnge(IEnumerable<T> entities);
    }
}
