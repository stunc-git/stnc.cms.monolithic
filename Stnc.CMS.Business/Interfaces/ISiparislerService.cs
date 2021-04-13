
using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;

namespace Stnc.CMS.Business.Interfaces
{
    public interface ISiparislerService : IGenericService<Siparisler>
    {
        int GetProjectTotal();
        List<Siparisler> ProjeList();

 
        // DekamProjeTakip GetSlugPost(string slug);
    }
}