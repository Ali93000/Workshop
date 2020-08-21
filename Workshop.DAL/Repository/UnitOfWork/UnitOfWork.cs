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
            UserRepository = new UserRepository(context);
            BranchRepository = new BranchRepository(context);
            VendorRepository = new VendorRepository(context);
            ServicesRepository = new ServicesRepository(context);
            ReceiptVoucherReopsitry = new ReceiptVoucherRepository(context);
            paymentVoucherReopsitry = new PaymentVoucherReopsitry(context);
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
        public IUserRepository UserRepository { get; }

        public IBranchRepository BranchRepository { get; }
         public IVendorRepository VendorRepository { get; }

        public IServicesRepository ServicesRepository { get; }

        public IReceiptVoucherReopsitry ReceiptVoucherReopsitry { get; }

        public IPaymentVoucherReopsitry paymentVoucherReopsitry { get; }
    }
}
