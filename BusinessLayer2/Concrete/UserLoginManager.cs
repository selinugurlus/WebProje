using BusinessLayer2.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer1.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer2.Concrete
{
    public class UserLoginManager : IUserLoginService
    {
        IUserDal _userDal;

        public UserLoginManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User GetUser(string usermail, string password)
        {
            return _userDal.Get(x => x.user_mail == usermail && x.user_password == password);
        }
    }
}
