using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Stnc.CMS.DataAccess.Interfaces;
using Stnc.CMS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
namespace Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfCartRepository : IShopDal
    {
        private readonly StncCMSContext _context;

        public EfCartRepository(StncCMSContext context)
        {
            _context = context;
        }

        public void Delete(StShoppingCartItem tablo)
        {
            throw new NotImplementedException();
        }

        public List<StShoppingCartItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public StShoppingCartItem GetById(int id)
        {
            throw new NotImplementedException();
        }


        public StShoppingCartItem GetCartId(int id)
        {
            throw new NotImplementedException();
        }
        public List<StShoppingCartItem> GetCartUserIdList(int userID)
        {
            var query = _context.StShoppingCartItem.Where(s => s.AppUserId == userID)
                //burada kaldım bunun için bir alan oluştur yani dto falan 
                .Select(I => new DeneyHayvaniIrkFiyatAjaxListDto()
                {
                    Id = I.Id,
                    YasBilgisi = I.YasBilgisi,
                    TurAdi = I.DekamProjeDeneyHayvaniIrk.Name,
                    GunlukBakimUcreti = I.DekamProjeDeneyHayvaniTur.GunlukBakimUcret,
                    OtenaziUcret = I.DekamProjeDeneyHayvaniTur.OtenaziUcret,
                    IrkAdi = I.DekamProjeDeneyHayvaniTur.Name,
                    Fiyat = I.Fiyat,
                }).
                OrderByDescending(I => I.Id);
            return query.ToList();
        }


        public void Save(StShoppingCartItem tablo)
        {
            throw new NotImplementedException();
        }

        public StShoppingCartItem SaveReturn(StShoppingCartItem tablo)
        {
            _context.Set<StShoppingCartItem>().Add(tablo);
            _context.SaveChanges();
            return tablo;
        }

        public void Update(StShoppingCartItem tablo)
        {
            throw new NotImplementedException();
        }







        /*
        public void DeleteProduct(int id)
        {
            var food = GetById(id);
            if (food == null)
            {
                throw new ArgumentException();
            }
            _context.Remove(food);
            _context.SaveChanges();
        }

        public void EditProduct(DekamProjeDeneyHayvaniIrkFiyat food)
        {
            var model = _context.DekamProjeDeneyHayvaniIrkFiyat.First(f => f.Id == food.Id);
            _context.Entry<DekamProjeDeneyHayvaniIrkFiyat>(model).State = EntityState.Detached;
            _context.Update(food);
            _context.SaveChanges();
        }

        public IEnumerable<DekamProjeDeneyHayvaniIrkFiyat> GetAll()
        {
            return _context.DekamProjeDeneyHayvaniIrkFiyat.ToList() ;
        }

        public DekamProjeDeneyHayvaniIrkFiyat GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }
        */

        //public IEnumerable<StCart> GetFilteredFoods(int id, string searchQuery)
        //{

        //    if (string.IsNullOrEmpty(searchQuery) || string.IsNullOrWhiteSpace(searchQuery))
        //    {
        //        return GetFoodsByCategoryId(id);
        //    }

        //    return GetFilteredFoods(searchQuery).Where(food => food.Category.Id == id);
        //}

        /*
        public IEnumerable<DekamProjeDeneyHayvaniIrkFiyat> GetFilteredProducts(string searchQuery)
        {
            var queries = string.IsNullOrEmpty(searchQuery) ? null : Regex.Replace(searchQuery, @"\s+", " ").Trim().ToLower().Split(" ");
            if (queries == null)
            {
                return GetPreferred(10);
            }

            return GetAll().Where(item => queries.Any(query => (item.Name.ToLower().Contains(query))));
        }
        */


        //public IEnumerable<StCart> GetFoodsByCategoryId(int categoryId)
        //{
        //    return GetAll().Where(food => food.Category.Id == categoryId);
        //}


    }
}
