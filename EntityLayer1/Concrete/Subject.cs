using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer1.Concrete
{
    public class Subject
    {   [Key]
        public int subject_id {get; set; }
        [StringLength(100)]
        public string subject_name { get; set; }

        public bool subject_status { get; set; }

        public int lesson_id { get; set; }  //lesson ve subject tabloları ilişkisi
        public virtual Lesson Lesson{ get; set; }

        public int user_id { get; set; } //ders konusunu kimin açtığini görmek için
        public virtual User User { get; set; }

        public ICollection<Content> Contents { get; set; } //content ve subject tabloları ilişkisi

    }
}
