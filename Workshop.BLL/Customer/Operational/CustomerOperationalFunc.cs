using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.DAL.Repository.UnitOfWork;

namespace Workshop.BLL.Customer.Operational
{
    public class CustomerOperationalFunc : ICustomerOperationalFunc
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerOperationalFunc(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public int CreateCustomer(W_D_Customer customerDB)
        {
            _unitOfWork.CustomerRepository.Add(customerDB);
            _unitOfWork.SaveChanges();
            return customerDB.Id; 
        }

        public void DeleteCustomer(int Id)
        {
            _unitOfWork.CustomerRepository.RemoveById(Id);
            _unitOfWork.SaveChanges();
        }

        public void UpdateCustomer(W_D_Customer customerDB)
        {
            _unitOfWork.CustomerRepository.Update(customerDB);
            _unitOfWork.SaveChanges();
        }
    }
}
