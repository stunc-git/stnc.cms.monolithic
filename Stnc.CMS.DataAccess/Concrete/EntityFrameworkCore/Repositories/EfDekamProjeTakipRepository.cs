using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Stnc.CMS.DataAccess.Interfaces;
using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfDekamProjeTakipRepository : EfGenericRepository<DekamProjeTakip>, IDekamProjeTakipDal
    {
        public int GetProjectTotal()
        {
            using var context = new StncCMSContext();
            return context.DekamProjeTakip.Count();
        }

        public List<DekamProjeTakip> ProjeList()
        {
            using var context = new StncCMSContext();
            return context.DekamProjeTakip.Include(I => I.Laboratuvar).OrderByDescending(I => I.Id).ToList();
        }
    }
}