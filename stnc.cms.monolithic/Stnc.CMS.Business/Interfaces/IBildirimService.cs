using System;
using System.Collections.Generic;
using System.Text;
using Stnc.CMS.Entities.Concrete;

namespace Stnc.CMS.Business.Interfaces
{
    public interface IBildirimService : IGenericService<Bildirim>
    {
        List<Bildirim> GetirOkunmayanlar(int AppUserId);
        int GetirOkunmayanSayisiileAppUserId(int AppUserId);
    }
}
