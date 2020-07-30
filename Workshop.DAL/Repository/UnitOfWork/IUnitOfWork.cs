using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Repository.Intefaces;

namespace Workshop.DAL.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();

        // Customer Repository
        ICustomerRepository CustomerRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
    }
}
