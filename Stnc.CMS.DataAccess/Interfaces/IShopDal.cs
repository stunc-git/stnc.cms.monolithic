using Stnc.CMS.DTO.DTOs.ShopCartDto;
using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stnc.CMS.DataAccess.Interfaces
{
    public interface IShopDal
    {
        //    IEnumerable<StShoppingCartItem> GetAll();
        //  IEnumerable<DekamProjeDeneyHayvaniIrkFiyat> GetPreferred(int count);
        //IEnumerable<DekamProjeDeneyHayvaniIrkFiyat> GetFoodsByCategoryId(int categoryId);
        //IEnumerable<DekamProjeDeneyHayvaniIrkFiyat> GetFilteredFoods(int id, string searchQuery);
        //IEnumerable<DekamProjeDeneyHayvaniIrkFiyat> GetFilteredFoods(string searchQuery);
        //   void NewProduct(DekamProjeDeneyHayvaniIrkFiyat cart);

        //StShoppingCartItem GetById(int id);

        //void EditProduct(StShoppingCartItem cart);
        //void DeleteProduct(int id);

        void Save(StShoppingCartItem tablo);

        void Delete(int id);

        void Update(StShoppingCartItem tablo);
                    
        StShoppingCartItem GetById(int id);

        StShoppingCartItem SaveReturn(StShoppingCartItem tablo);

        List<StShoppingCartItem> GetAll();

        List<ShopCartAjaxListDto> GetCartUserIdList(int userID);
        // List<ShopCartAjaxListDto> GetCartSiparislerIDList(int SiparislerID);

        Task<List<ShopCartAjaxListDto>> GetCartSiparislerIDList(int SiparislerID);

        decimal ToplamUcret(int userID);
        decimal ToplamUcretSiparislerID(int SiparislerID);

        int ToplamUrunAdeti(int userID);

        void UpdateSiparislerID(int id, int value);
    }
}