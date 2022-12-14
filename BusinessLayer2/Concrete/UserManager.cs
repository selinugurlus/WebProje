using BusinessLayer2.Abstract;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete.Repositories;
using EntityLayer1.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer2.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<User> GetUserList()
        {
            return _userDal.List(); //genericrepository metotları geldi.
        }

        public void UserAdd(User user)
        {
            _userDal.Insert(user);
        }
    }
}
