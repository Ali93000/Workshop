using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;

namespace Workshop.DAL.Repository.Intefaces
{
    public interface IUserRepository : IGenericRepository<G_USERS>
    {
        G_USERS UserLoginData(Expression<Func<G_USERS, bool>> predicate);
    }
}
