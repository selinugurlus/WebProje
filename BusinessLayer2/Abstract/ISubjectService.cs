using EntityLayer1.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer2.Abstract
{
    public interface ISubjectService
    {
        List<Subject> GetSubjectList();
        List<Subject> GetSubjectListByUser(int id);
        void SubjectAdd(Subject subject);
        Subject GetByID(int id);
        void SubjectDelete(Subject subject);
        void SubjectUpdate(Subject subject);

    }
}
