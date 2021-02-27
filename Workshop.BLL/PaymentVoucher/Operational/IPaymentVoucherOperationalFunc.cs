using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Entities.ApiModels.PaymentVoucher.Request;
using Workshop.Entities.DTO.User;

namespace Workshop.BLL.PaymentVoucher.Operational
{
   public interface IPaymentVoucherOperationalFunc
    {
        int CreatPaymentVoucher(PaymentVoucherReq paymentVoucherReq, UserDTO userInfo);
        void UpdatePaymentVoucher(PaymentVoucherReq paymentVoucherReq, UserDTO userInfo);
        void DeletePaymentVoucher(int id);
       
    }
}
