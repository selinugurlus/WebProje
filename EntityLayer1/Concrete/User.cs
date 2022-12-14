using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer1.Concrete
{
    public class User
    {
        [Key]
        public int user_id { get; set; }
       [StringLength(50)]
        public string user_name { get; set; }
       [StringLength(50)]
        public string user_surname { get; set; }
       [StringLength(100)]
        public string user_mail { get; set; }
       [StringLength(100)]
        public string user_password { get; set; }

        public bool user_status { get; set; }

        public ICollection<Subject> Subjects { get; set; }
        public ICollection<Content> Contents { get; set; } 
    }
}
