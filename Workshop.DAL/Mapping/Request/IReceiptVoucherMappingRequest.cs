using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.Entities.ApiModels.CashReceipt.Request;

namespace Workshop.DAL.Mapping.Request
{
  public  interface IReceiptVoucherMappingRequest 
    {
        W_T_ReceiptVoucher mapFromCachReceiptReqToDB(ReceiptVoucherReq cachReceiptReq);
    }
}
