using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.DAL.Repository.Intefaces;

namespace Workshop.DAL.Repository.Implementation
{
    public class BranchRepository : GenericRepository<G_Branches>, IBranchRepository
    {
        private readonly DbContext _context;
        public BranchRepository(DbContext context) : base(context)
        {
            this._context = context;
        }
    }
}
