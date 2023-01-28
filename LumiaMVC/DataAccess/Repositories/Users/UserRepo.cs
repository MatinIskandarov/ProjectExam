using DataAccess.Abstract.Users;
using DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Users
{
    public class UserRepo : IUser
    {
        private readonly AppDbContext _context;

        public UserRepo(AppDbContext context)
        {
            _context = context;
        }

        public bool UserIsExist(string username, string password)
        {
            return _context.Users.Any(x => x.Username == username && x.Password == password && x.IsActive == true);
        }
    }
}
