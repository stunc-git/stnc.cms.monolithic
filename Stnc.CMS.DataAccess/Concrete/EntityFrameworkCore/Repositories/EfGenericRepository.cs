using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Stnc.CMS.DataAccess.Interfaces;
using Stnc.CMS.Entities.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<Tablo> : IGenericDal<Tablo> where Tablo : class, ITablo, new()
    {
        public List<Tablo> GetAll()
        {
            using var context = new StncCMSContext();
            return context.Set<Tablo>().ToList();
        }

        public Tablo GetID(int id)
        {
            using var context = new StncCMSContext();
            return context.Set<Tablo>().Find(id);
        }

        public void Update(Tablo tablo)
        {
            using var context = new StncCMSContext();
            context.Set<Tablo>().Update(tablo);
            context.SaveChanges();
        }

        public void Save(Tablo tablo)
        {
            using var context = new StncCMSContext();
            context.Set<Tablo>().Add(tablo);
            context.SaveChanges();
        }

        public Tablo SaveReturn(Tablo tablo)
        {
            using var context = new StncCMSContext();
            context.Set<Tablo>().Add(tablo);
            context.SaveChanges();
            return tablo;
        }

        public void Delete(Tablo tablo)
        {
            using var context = new StncCMSContext();
            context.Set<Tablo>().Remove(tablo);
            context.SaveChanges();

            /*
                         using var context = new StncCMSContext();
            var post= new Posts { Id = id };
            context.Posts.Attach(post);
            context.Posts.Remove(post);
            context.SaveChanges();
             */
        }
    }
}