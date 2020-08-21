using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.Entities.DTO.User;

namespace Workshop.DAL.Repository.Intefaces
{
  public interface IPaymentVoucherReopsitry :IGenericRepository<W_T_PaymentVoucher>
    {
        string GetLastCode(UserDTO userInfo);
      
    }
}
