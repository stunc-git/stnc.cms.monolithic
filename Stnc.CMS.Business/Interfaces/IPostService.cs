using Stnc.CMS.DTO.DTOs.PostDtos;
using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;

namespace Stnc.CMS.Business.Interfaces
{
    public interface IPostService : IGenericService<Posts>
    {

        int GetTotalPost();
        
        List<Posts> PostList();
        /*
List<Gorev> GetirAciliyetIleTamamlanmayan();
List<Gorev> GetirTumTablolarla();
Gorev GetirAciliyetileId(int id);
List<Gorev> GetirileAppUserId(int appUserId);
Gorev GetirRaporlarileId(int id);
List<Gorev> GetirTumTablolarla(Expression<Func<Gorev, bool>> filter);
List<Gorev> GetirTumTablolarlaTamamlanmayan(out int toplamSayfa, int userId, int aktifSayfa=1);
int GetirGorevSayisiTamamlananileAppUserId(int id);
int GetirGorevSayisiTamamlanmasiGerekenileAppUserId(int id);
int GetirGorevSayisiAtanmayiBekleyen();
int GetirGorevTamamlanmis();
*/
    }
}
