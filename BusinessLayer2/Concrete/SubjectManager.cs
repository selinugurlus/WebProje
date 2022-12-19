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
    public class SubjectManager : ISubjectService
    {
        ISubjectDal _subjectDal;

        public SubjectManager(ISubjectDal subjectDal)
        {
            _subjectDal = subjectDal;
        }
        public Subject GetByID(int id)
        {
            return _subjectDal.Get(x => x.subject_id == id);
        }

        public List<Subject> GetSubjectList()
        {
            return _subjectDal.List();
        }

        public List<Subject> GetSubjectListByUser()
        {
            return _subjectDal.List(x => x.user_id ==1);
        }

        public void SubjectAdd(Subject subject)
        {
            _subjectDal.Insert(subject);
        }

        public void SubjectDelete(Subject subject)
        {
             
            _subjectDal.Update(subject);
        }

        public void SubjectUpdate(Subject subject)
        {
            _subjectDal.Update(subject);
        }
    }
}
