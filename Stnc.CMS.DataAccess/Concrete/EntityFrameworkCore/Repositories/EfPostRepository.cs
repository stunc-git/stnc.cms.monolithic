﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Stnc.CMS.DataAccess.Interfaces;
using Stnc.CMS.Entities.Concrete;

namespace Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfPostRepository : EfGenericRepository<Posts>, IPostDal
    {
       

        public int ToplamPostAdeti()
        {
            using var context = new StncCMSContext();
            return context.Posts.Count();
        }

    }
}