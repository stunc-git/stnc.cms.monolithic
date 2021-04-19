using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Stnc.CMS.DataAccess.Interfaces;
using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfSiparislerRepository : EfGenericRepository<Siparisler>, ISiparislerDal
    {
        public int GetProjectTotal()
        {
            using var context = new StncCMSContext();
            return context.Siparisler.Count();
        }

        public List<Siparisler> ProjeList()
        {
            using var context = new StncCMSContext();
            return context.Siparisler.Include(I => I.DekamProjeLaboratuvarlar).OrderByDescending(I => I.Id).ToList();
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