using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.EntityFramework;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
