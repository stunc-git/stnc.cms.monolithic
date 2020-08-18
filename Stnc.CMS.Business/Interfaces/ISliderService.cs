using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;

namespace Stnc.CMS.Business.Interfaces
{
    public interface ISliderService : IGenericService<Slider>
    {
        List<Slider> SliderList();
    }
}