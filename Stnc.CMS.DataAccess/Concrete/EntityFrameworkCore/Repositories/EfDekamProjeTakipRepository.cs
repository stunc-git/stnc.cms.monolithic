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
            return context.DekamProjeTakip.Include(I => I.DekamProjeLaboratuvarlar).OrderByDescending(I => I.Id).ToList();
        }

        //selman alacak 
        //public void DekamProjeTakipIDUpdate(int DekamProjeTakipID, int value)
        //{
        //    using var context = new StncCMSContext();
        //    Options opt = context.DekamProjeTakip.Where(I => I == DekamProjeTakipID).FirstOrDefault();
        //    opt.OptionValue = value;
        //    context.SaveChanges();
        //}

    }
}