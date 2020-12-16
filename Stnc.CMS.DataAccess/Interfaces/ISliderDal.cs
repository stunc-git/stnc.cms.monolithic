using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;

namespace Stnc.CMS.DataAccess.Interfaces
{
    public interface ISliderDal : IGenericDal<Slider>
    {
        List<Slider> SliderList();
    }
}