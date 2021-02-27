using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;

namespace Workshop.DAL.Repository.Intefaces
{
    public interface IReceiptVoucherReopsitry : IGenericRepository<W_T_ReceiptVoucher>
    {
        int getMaxCode();
    
    }
}
