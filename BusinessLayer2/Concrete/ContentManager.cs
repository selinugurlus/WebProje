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
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void ContentAdd(Content content)
        {
            throw new NotImplementedException();
        }

        public void ContentDelete(Content content)
        {
            throw new NotImplementedException();
        }

        public void ContentUpdate(Content content)
        {
            throw new NotImplementedException();
        }

        public Content GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetContentList()
        {
            throw new NotImplementedException();
        }

        public List<Content> GetContentListByUser()
        {
            return _contentDal.List(x => x.user_id == 1);
        }

        public List<Content> GetListBySubjectID(int id)
        {
            return _contentDal.List(x => x.content_id == id);
        }
    }
}
