using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.DAL.Repository.Intefaces;

namespace Workshop.DAL.Repository.Implementation
{
    public class ReceiptVoucherRepository : GenericRepository<W_T_ReceiptVoucher>, IReceiptVoucherReopsitry
    {
        private readonly DbContext _context;
        public ReceiptVoucherRepository(DbContext context) : base(context)
        { 
            this._context = context; 
        }

       
        public int getMaxCode()
        {
            List<W_T_ReceiptVoucher> list = _context.Set<W_T_ReceiptVoucher>().ToList();
            int? code = list.Select(x => x.TrCode).Max();
            return code.Value;
        }
    }
}

