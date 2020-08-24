using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;

namespace Stnc.CMS.Business.Interfaces
{
    public interface IDekamProjeTakipService : IGenericService<DekamProjeTakip>
    {
        int GetTotalProject();
        List<DekamProjeTakip> ProjectList();
      //  Posts GetSlugPost(string slug);
    }
}