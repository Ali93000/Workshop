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
    public class ItemRepository : GenericRepository<W_D_Items>, IItemRepository
    {
        private readonly DbContext _context;
        public ItemRepository(DbContext context) : base(context)
        {
            this._context = context;
        }
    }
}
