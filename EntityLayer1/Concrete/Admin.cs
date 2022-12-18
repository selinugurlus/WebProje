using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer1.Concrete
{
    public class Admin
    {
        [Key]
        public int admin_id { get; set; }
        [StringLength(50)]
        public string admin_username { get; set; }
        [StringLength(50)]
        public string admin_password { get; set; }
       [StringLength(1)]
        public string admin_role { get; set; }

    }
}
