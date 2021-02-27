using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.DAL.Repository.Intefaces;

namespace Workshop.DAL.Repository.Implementation
{
    public class VendorRepository : GenericRepository<W_D_Vendor>, IVendorRepository
    {
        private readonly DbContext _context;
        public VendorRepository(DbContext context) : base(context)
        {
            this._context = context;
        }

        public bool isMonil(string mobil)
        {
            return _context.Set<W_D_Vendor>().Any(x => x.Mobile1 == mobil);
        }
    }
}
