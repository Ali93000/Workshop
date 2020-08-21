using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Repository.Implementation;
using Workshop.Entities.ApiModels.CashReceipt.Response;

namespace Workshop.BLL.CachReceipt.Enquiry
{
   public interface IReceiptVoucherEnquiryFunc
    {
        ReceiptVoucherResponse GetAllCashReceipt();
        ReceiptVoucherIDResponse GetCachById(int id);
    }
}
