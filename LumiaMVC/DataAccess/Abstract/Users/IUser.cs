using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.Users
{
    public interface IUser
    {
        bool UserIsExist(string username, string password);
    }
}
