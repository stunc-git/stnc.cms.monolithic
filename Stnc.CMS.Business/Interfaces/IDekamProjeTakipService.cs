
using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;

namespace Stnc.CMS.Business.Interfaces
{
    public interface IDekamProjeTakipService : IGenericService<DekamProjeTakip>
    {
        int GetProjectTotal();
        List<DekamProjeTakip> ProjeList();

 
        // DekamProjeTakip GetSlugPost(string slug);
    }
}