using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.DAL.Repository.Intefaces;
using Workshop.Entities.DTO.User;

namespace Workshop.DAL.Repository.Implementation
{
    public class PaymentVoucherReopsitry : GenericRepository<W_T_PaymentVoucher>, IPaymentVoucherReopsitry
    {
        private readonly DbContext _dbContext;
        public PaymentVoucherReopsitry(DbContext context) : base(context)
        {
            this._dbContext = context;
        }

        public string GetLastCode(UserDTO userInfo)
        {
            List<W_T_PaymentVoucher> list = _dbContext.Set<W_T_PaymentVoucher>().ToList();
            var code = list.Where(x => x.CompanyCode == userInfo.CompCode && x.BranchCode == userInfo.BraCode).Select(c => c.TrCode).Max();
            return code.ToString();
        }
    }
}
