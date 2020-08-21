using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;

namespace Stnc.CMS.Business.Interfaces
{
    public interface IDekamProjeTakipService : IGenericService<DekamProjeTakip>
    {
        int GetTotalProjeTakip();
        List<DekamProjeTakip> DekamProjeTakipServiceList();
        //Posts GetSlugPost(string slug);
    }
}
