﻿using Stnc.CMS.Entities.Concrete;
using System.Collections.Generic;

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

        void Delete(StShoppingCartItem tablo);

        void Update(StShoppingCartItem tablo);

        StShoppingCartItem GetById(int id);

        StShoppingCartItem SaveReturn(StShoppingCartItem tablo);

        List<StShoppingCartItem> GetAll();


    }
}