using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.DAL.Repository.Intefaces;

namespace Workshop.DAL.Repository.Implementation
{
    public class UserRepository : GenericRepository<G_USERS>, IUserRepository
    {
        private readonly DbContext _context;
        public UserRepository(DbContext context) : base(context)
        {
            this._context = context;
        }

        public G_USERS UserLoginData(Expression<Func<G_USERS, bool>> predicate)
        {
            return _context.Set<G_USERS>().Include(u => u.UserRoles).FirstOrDefault(predicate);
        }
    }
}
