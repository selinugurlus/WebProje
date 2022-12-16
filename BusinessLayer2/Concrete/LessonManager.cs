using BusinessLayer2.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer1.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer2.Concrete
{
    public class LessonManager:ILessonService
    {
        ILessonDal _lessonDal;

        public LessonManager(ILessonDal lessonDal)
        {
            _lessonDal = lessonDal;
        }

        public Lesson GetByID(int id)
        {
            return _lessonDal.Get(x=>x.lesson_id==id);
        }

        

        public List<Lesson> GetLessonList()
        {
            return _lessonDal.List(); //genericrepository metotları geldi.
        }
        //public void LessonAdd(Lesson lesson)
        //{
        //    _lessonDal.Insert(lesson);
        //}

        public void LessonAdd(Lesson lesson)
        {
            _lessonDal.Insert(lesson);
        }

        public void LessonDelete(Lesson lesson)
        {
            _lessonDal.Delete(lesson);
        }

        public void LessonUpdate(Lesson lesson)
        {
            _lessonDal.Update(lesson);
        }
    }
}

