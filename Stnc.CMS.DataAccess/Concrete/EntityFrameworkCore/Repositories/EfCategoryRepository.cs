﻿using Stnc.CMS.DataAccess.Interfaces;
using Stnc.CMS.Entities.Concrete;

namespace Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfIDPRelationGenericRepository : EfGenericRepository<Category>, ICategoryDal
    {
    }
}