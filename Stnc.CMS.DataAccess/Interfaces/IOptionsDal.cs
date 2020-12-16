using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;

namespace Stnc.CMS.DataAccess.Interfaces
{
    public interface IOptionsDal 
    {
        string GetOptionName(string slug);
        string GetOptionNameDefault(string slug);
        string GetOptionID(int ID);  
        Options GetOptionNameRow(string slug);
        Options GetOptionIDRow(int ID);
        Options SaveReturn(Options tablo);
        void Update(string key, string value);
    }
}