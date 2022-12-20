using EntityLayer1.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer2.Abstract
{
    public interface IContentService
    {
        List<Content> GetContentList();
        List<Content> GetContentListByUser(int id);
        List<Content> GetListBySubjectID(int id);
        void ContentAdd(Content content);
        Content GetByID(int id);
        void ContentDelete(Content content);
        void ContentUpdate(Content content);

    }
}
