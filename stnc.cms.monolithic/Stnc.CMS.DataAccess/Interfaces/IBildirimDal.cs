using System;
using System.Collections.Generic;
using System.Text;
using Stnc.CMS.Entities.Concrete;

namespace Stnc.CMS.DataAccess.Interfaces
{
    public interface IBildirimDal : IGenericDal<Bildirim>
    {
        List<Bildirim> GetirOkunmayanlar(int AppUserId);
        int GetirOkunmayanSayisiileAppUserId(int AppUserId);
    }
}
