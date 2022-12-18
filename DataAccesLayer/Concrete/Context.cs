using EntityLayer1.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Concrete
{
    public class Context:DbContext
    {
       public DbSet <User> Userss { get; set; }
       public DbSet <Lesson> Lessons { get; set; }
       public DbSet<Content> Contents { get; set; }
       public DbSet <Subject> Subjects { get; set; }
       public DbSet <Admin> Admins { get; set; }


    }
}
