using Stnc.CMS.Business.Interfaces;
using Stnc.CMS.DataAccess.Interfaces;
using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;

namespace Stnc.CMS.Business.Concrete
{
    public class OptionsManager : IOptionsService
    {
        private readonly IOptionsDal _optionsDal;


        public OptionsManager(IOptionsDal optionsDal)
        {
            _optionsDal = optionsDal;
        }

        public string GetOptionID(int ID)
        {
            return _optionsDal.GetOptionID(ID);
        }

        public string GetOptionName(string slug)
        {
            return _optionsDal.GetOptionName(slug);
        }


        public string GetOptionNameDefault(string slug)
        {
            return _optionsDal.GetOptionNameDefault(slug);
        }

        public Options GetOptionIDRow(int ID)
        {
            return _optionsDal.GetOptionIDRow(ID);
        }

        public  Options GetOptionNameRow(string slug)
        {
            return _optionsDal.GetOptionNameRow(slug);
        }
   
        public Options SaveReturn(Options tablo)
        {
            return _optionsDal.SaveReturn(tablo);
        }

        public void Update(string key, string value)
        {
             _optionsDal.Update(key, value);
        }
    }
}