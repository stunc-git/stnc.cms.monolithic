using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Stnc.CMS.DataAccess.Interfaces;
using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfSliderRepository : EfGenericRepository<Slider>, ISliderDal
    {
        public List<Slider> SliderList()
        {
            using var context = new StncCMSContext();
            return context.Slider.Where(I => I.Status).OrderByDescending(I => I.Id).ToList();
        }
    }
}