using System;
using System.Collections.Generic;
using System.Text;
using Stnc.CMS.Entities.Concrete;

namespace Stnc.CMS.Business.Interfaces
{
    public interface IRaporService : IGenericService<Rapor>
    {
        Rapor GetirGorevileId(int id);
        int GetirRaporSayisiileAppUserId(int id);
        int GetirRaporSayisi();
    }
}
