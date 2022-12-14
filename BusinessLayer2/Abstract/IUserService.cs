using EntityLayer1.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer2.Abstract
{
    public interface IUserService
    {
        List<User> GetUserList();
    }
}
