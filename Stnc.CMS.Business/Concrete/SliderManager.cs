using Stnc.CMS.Business.Interfaces;
using Stnc.CMS.DataAccess.Interfaces;
using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;

namespace Stnc.CMS.Business.Concrete
{
    public class SliderManager : ISliderService
    {
        private readonly ISliderDal _sliderDal;

        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public List<Slider> GetAll()
        {
            return _sliderDal.GetAll();
        }

        public Slider GetirIdile(int id)
        {
            return _sliderDal.GetirIdile(id);
        }

        public void Guncelle(Slider tablo)
        {
            _sliderDal.Guncelle(tablo);
        }

        public void Kaydet(Slider tablo)
        {
            _sliderDal.Kaydet(tablo);
        }

        public Slider SaveReturn(Slider tablo)
        {
            return _sliderDal.SaveReturn(tablo);
        }

        public void Sil(Slider tablo)
        {
            _sliderDal.Sil(tablo);
        }

        public List<Slider> SliderList()
        {
            return _sliderDal.SliderList();
        }
    }
}