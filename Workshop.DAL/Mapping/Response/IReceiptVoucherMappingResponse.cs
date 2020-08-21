using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.DAL.Repository.Implementation;
using Workshop.Entities.ApiModels.CashReceipt.Response;
using Workshop.Entities.DTO.CachReceipt;

namespace Workshop.DAL.Mapping.Response
{
    public interface IReceiptVoucherMappingResponse
    {
        ReceiptVoucherResponse mapFromDbToCashReceiptDTOResponse(IEnumerable<W_T_ReceiptVoucher> cachReceipts);
        ReceiptVoucherIDResponse maoFromDbToCachreceiptDTO(W_T_ReceiptVoucher CachReceiptId);
    }
}
