using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Stnc.CMS.DataAccess.Interfaces;
using Stnc.CMS.Entities.Interfaces;

namespace Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<Tablo> : IGenericDal<Tablo>
        where Tablo : class, ITablo, new()
    {
        public List<Tablo> GetirHepsi()
        {
          
            using var context = new StncCMSContext();
            return context.Set<Tablo>().ToList();
        }

        public Tablo GetirIdile(int id)
        {
            using var context = new StncCMSContext();
            return context.Set<Tablo>().Find(id);
        }

        public void Guncelle(Tablo tablo)
        {
            using var context = new StncCMSContext();
            context.Set<Tablo>().Update(tablo); 
            context.SaveChanges();
        }

        public void Kaydet(Tablo tablo)
        {
            using var context = new StncCMSContext();
            context.Set<Tablo>().Add(tablo);
            context.SaveChanges();
        }

        public void Sil(Tablo tablo)
        {
            using var context = new StncCMSContext();
            context.Set<Tablo>().Remove(tablo);
            context.SaveChanges();
        }
    }
}
