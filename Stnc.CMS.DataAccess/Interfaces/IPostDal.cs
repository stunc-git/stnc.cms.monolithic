using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Stnc.CMS.Entities.Concrete;

namespace Stnc.CMS.DataAccess.Interfaces
{
    public interface IPostDal : IGenericDal<Posts>
    {
        //List<Gorev> GetirAciliyetIleTamamlanmayan();
        //List<Gorev> GetirTumTablolarla();
        //List<Gorev> GetirTumTablolarla(Expression<Func<Gorev, bool>> filter);
        //List<Gorev> GetirTumTablolarlaTamamlanmayan(out int toplamSayfa, int userId, int aktifSayfa = 1);
        //Gorev GetirAciliyetileId(int id);
        //List<Gorev> GetirileAppUserId(int appUserId);
        //Gorev GetirRaporlarileId(int id);

        //int GetirGorevSayisiTamamlananileAppUserId(int id);
        //int GetirGorevSayisiTamamlanmasiGerekenileAppUserId(int id);
        //int GetirGorevSayisiAtanmayiBekleyen();
        List<Posts> PostList();
        int GetTotalPost();
    }
}
