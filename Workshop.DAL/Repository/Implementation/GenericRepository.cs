using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Repository.Intefaces;

namespace Workshop.DAL.Repository.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _entites;

        public GenericRepository(DbContext context)
        {
            this._context = context;
            this._entites = context.Set<T>();
        }

        public void Add(T entity)
        {
            _entites.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _entites.AddRange(entities);
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _entites.Where(predicate).ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return _entites.ToList();
        }

        public T GetById(int Id)
        {
            return _entites.Find(Id);
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _entites.FirstOrDefault(predicate);
        }

        public void Remove(T entity)
        {
            _entites.Remove(entity);
        }

        public void RemoveById(int Id)
        {
            T res = _entites.Find(Id);
            _entites.Remove(res);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _entites.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _entites.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateRAnge(IEnumerable<T> entities)
        {
            foreach (T item in entities)
            {
                _entites.Attach(item);
                _context.Entry(item).State = EntityState.Modified;
            }
        }
    }
}
