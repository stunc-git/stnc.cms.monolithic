using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;

namespace Stnc.CMS.DataAccess.Interfaces
{
    public interface IShopDal
    {
        IEnumerable<StCart> GetAll();
        IEnumerable<StCart> GetPreferred(int count);
        //IEnumerable<StCart> GetFoodsByCategoryId(int categoryId);
        //IEnumerable<StCart> GetFilteredFoods(int id, string searchQuery);
        //IEnumerable<StCart> GetFilteredFoods(string searchQuery);
        StCart GetById(int id);
        void NewFood(StCart cart);
        void EditFood(StCart cart);
        void DeleteFood(int id);
    }
}