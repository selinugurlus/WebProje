using DataAccesLayer.Concrete.Repositories;
using EntityLayer1.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer2.Concrete
{
    public class UserManager
    {
        GenericRepository<User> repo = new GenericRepository<User>();

        public List<User> GetAll()
        {
            return repo.List();
        }

        public void UserAddBL(User u)
        {
            if(u.user_mail==null||u.user_name==null||u.user_surname==null||u.user_password==null)
            {
                //hata mesajı
            }
            else
            {
                repo.Insert(u);
            }
        }
    }
}
