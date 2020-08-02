using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.DAL.Repository.Implementation;
using Workshop.DAL.Repository.Intefaces;

namespace Workshop.DAL.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WorkshopDBEntities _context;

        public UnitOfWork(WorkshopDBEntities context)
        {
            this._context = context;
            CustomerRepository = new CustomerRepository(context);
            EmployeeRepository = new EmployeeRepository(context);
            CategoryRepository = new CategoryRepository(context);
            ItemRepository = new ItemRepository(context);
        }

        // 
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            this._context.Dispose();
        }

        public ICustomerRepository CustomerRepository { get; }
        public IEmployeeRepository EmployeeRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public IItemRepository ItemRepository { get; }
    }
}
