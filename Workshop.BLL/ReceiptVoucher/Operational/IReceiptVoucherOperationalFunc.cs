using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Entities.ApiModels.CashReceipt.Request;

namespace Workshop.BLL.CachReceipt.Operational
{
 public interface IReceiptVoucherOperationalFunc
    {
        int CreateCachReceipt(ReceiptVoucherReq cachReceiptReq);
        void UpdateCachReceipt(ReceiptVoucherReq cachReceiptReq);
        void DeleteCachReceipt( int id);
       

    }
}
