using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer1.Concrete
{
    public class Content
    {
        [Key]
        public int content_id { get; set; }
        [StringLength(2000)]
        public string content_value { get; set; }

       public int subject_id { get; set; }
       public virtual Subject Subject { get; set; }

        public int ? user_id { get; set; }
        public virtual User User { get; set; }

    }
}
