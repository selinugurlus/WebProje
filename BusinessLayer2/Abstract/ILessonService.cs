using EntityLayer1.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer2.Abstract
{
    public interface ILessonService
    {
        List<Lesson> GetLessonList();
        void LessonAdd(Lesson lesson);
        Lesson GetByID(int id);
        void LessonDelete(Lesson lesson);
        void LessonUpdate(Lesson lesson);


    }
}
