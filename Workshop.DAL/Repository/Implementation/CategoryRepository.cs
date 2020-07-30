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
    public class CategoryRepository : GenericRepository<W_D_Category>, ICategoryRepository
    {
        private readonly DbContext _context;
        public CategoryRepository(DbContext context) : base(context)
        {
            this._context = context;
        }
    }
}
