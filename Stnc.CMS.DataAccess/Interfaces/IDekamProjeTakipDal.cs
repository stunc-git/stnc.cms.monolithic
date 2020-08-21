using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;

namespace Stnc.CMS.DataAccess.Interfaces
{
    public interface IDekamProjeTakipDal : IGenericDal<DekamProjeTakip>
    {
        int GetTotalProjeTakip();

        List<DekamProjeTakip> ProjeTakipList();

        //ProjeTakipList GetSlugProjeTakip(string Slug);
    }
}