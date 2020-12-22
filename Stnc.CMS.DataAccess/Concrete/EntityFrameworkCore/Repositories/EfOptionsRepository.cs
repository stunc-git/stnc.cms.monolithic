
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
    public class EfOptionsRepository : IOptionsDal
    {
        private readonly StncCMSContext _context;

        public EfOptionsRepository(StncCMSContext context)
        {
            _context = context;
        }

        public string GetOptionID(int ID)
        {
          //  var data= _context.Options.Select(I => new Options(){OptionValue = I.OptionValue }).Where(I => I.Id == ID).FirstOrDefault();
            var data= _context.Options.Where(I => I.Id == ID).FirstOrDefault();
            return data.OptionValue;
        }

        public string GetOptionName(string Slug)
        {
            var data = _context.Options.Where(I => I.OptionName == Slug).FirstOrDefault();
            return data.OptionValue;
        }

        public string GetOptionNameDefault(string Slug)
        {
            var data = _context.Options.Where(I => I.OptionName == Slug).FirstOrDefault();
            return data.DefaultValue;
        }

        public Options GetOptionIDRow(int ID)
        {
            return _context.Options.Where(I => I.Id == ID).OrderByDescending(I => I.Id).FirstOrDefault();
        }

        public Options GetOptionNameRow(string Slug)
        {
            return _context.Options.Where(I => I.OptionName == Slug).OrderByDescending(I => I.Id).FirstOrDefault();
            //   return context.Posts.Where(I => I.PostSlug == Slug).OrderByDescending(I => I.Id).FirstOrDefault();
        }

        public Options SaveReturn(Options tablo)
        {
            _context.Set<Options>().Add(tablo);
            _context.SaveChanges();
            return tablo;
        }

        public void Update(string key, string value)
        {
            //Options opt = _context.Options.Where(I => I.OptionName == key).FirstOrDefault();
            //opt.OptionValue = value;
            //_context.SaveChanges();


            Options result = _context.Options.SingleOrDefault(I => I.OptionName == key);
            if (result != null)
            {
                result.OptionValue = value;
                _context.SaveChanges();
            }

        }


    }
}
