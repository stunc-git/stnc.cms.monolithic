using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;

namespace Stnc.CMS.DataAccess.Interfaces
{
    public interface ISiparislerDal : IGenericDal<Siparisler>
    {
        int GetProjectTotal();
        List<Siparisler> ProjeList();
        // DekamProjeTakip GetSlugPost(string slug);
    }
}