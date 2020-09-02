
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Stnc.CMS.DataAccess.Interfaces;
using Stnc.CMS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfPostRepository : EfGenericRepository<Posts>, IPostDal
    {
        private readonly StncCMSContext _context;

        public EfPostRepository(StncCMSContext context)
        {
            _context = context;
        }



        public int GetTotalPost()
        {
            using var context = new StncCMSContext();
            return context.Posts.Count();
        }

      //  public List<Posts>    PostList()
       public List<Posts>    PostList()
        {
            //  using var context = new StncCMSContext();
            // using var context = new StncCMSContext();
            //  return _context.Posts.TagWith("InsertTweetStoreProc + LogContext").ToList();
            //IQueryable<Posts> query
            var query = _context.Posts.Include(I => I.AppUser).Where(I => I.PostStatus).OrderByDescending(I => I.Id);


          // Console.WriteLine(query.TagWith("tuyuıuyıyuıyuıyuıyuıyuıyuıyuıuyıyuıuy"));

           return query.ToList();
        }

        public Posts GetSlugPost(string Slug)
        {
            using var context = new StncCMSContext();
            return context.Posts.Where(I => I.PostSlug == Slug).OrderByDescending(I => I.Id).FirstOrDefault();
        }
    }
}