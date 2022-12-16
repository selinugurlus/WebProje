using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer1.Concrete
{
    public class Lesson
    {   [Key]
        public int lesson_id { get; set; }
        [StringLength(50)]
        public string lesson_name { get; set; }
        public bool lesson_status { get; set; }
        
        public ICollection<Subject> Subjects { get; set;  }
    }
}
