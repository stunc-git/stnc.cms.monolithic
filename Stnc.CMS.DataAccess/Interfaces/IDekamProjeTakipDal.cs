using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;

namespace Stnc.CMS.DataAccess.Interfaces
{
    public interface IDekamProjeTakipDal : IGenericDal<DekamProjeTakip>
    {
        int GetProjectTotal();
        List<DekamProjeTakip> ProjeList();
        // DekamProjeTakip GetSlugPost(string slug);
    }
}