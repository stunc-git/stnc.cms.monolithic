using System;
using System.Collections.Generic;
using System.Text;
using Stnc.CMS.Entities.Concrete;

namespace Stnc.CMS.DataAccess.Interfaces
{
    public interface IRaporDal : IGenericDal<Rapor>
    {
        Rapor GetirGorevileId(int id);
        int GetirRaporSayisiileAppUserId(int id);
        int GetirRaporSayisi();
    }
}
