using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Stnc.CMS.DataAccess.Interfaces;
using Stnc.CMS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Stnc.CMS.DTO.DTOs.ShopCartDto;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Repositories
{


    public class EfCartRepository : IShopDal
    {
        private readonly StncCMSContext _context;

        public EfCartRepository(StncCMSContext context)
        {
            _context = context;
        }

 
        public void Delete(int id)
        {


            var d = new StShoppingCartItem { Id = id };
            _context.StShoppingCartItem.Attach(d);
            _context.StShoppingCartItem.Remove(d);
            _context.SaveChanges();

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


        public decimal ToplamUcret(int userID)
        {
            return _context.StShoppingCartItem.Where(I => I.AppUserId == userID).Sum(p => p.ToplamFiyat);
        }

        public decimal ToplamUcretSiparislerID(int SiparislerID)
        {
            return _context.StShoppingCartItem.Where(I => I.SiparislerID == SiparislerID).Sum(p => p.ToplamFiyat);
        }

        public int ToplamUrunAdeti(int userID)
        {
            return _context.StShoppingCartItem.Where(I => I.AppUserId == userID).Count();
        }

        //burada kaldım bunun için bir alan oluştur yani dto falan 
        public List<ShopCartAjaxListDto> GetCartUserIdList(int userID)
        {
            //return context.DekamProjeDeneyHayvaniIrkFiyat.Include(I => I.DekamProjeDeneyHayvaniIrk).Include(I => I.DekamProjeDeneyHayvaniTur).Include(I => I.AppUser).OrderByDescending(I => I.CreatedAt).ToList();
            return _context.StShoppingCartItem.Select(I => new ShopCartAjaxListDto()
                {
                    HayvaniIrkFiyatID = I.HayvaniIrkFiyatID,
                    HayvanIrkAdi = I.HayvanIrkAdi,
                    HayvanAdi = I.HayvanAdi,
                    HayvanIrkFiyatTipYasBilgisi = I.HayvanIrkFiyatTipYasBilgisi,
                    IstenenHayvanSayisi = I.IstenenHayvanSayisi,
                    BakimDestegiGunSayisi = I.BakimDestegiGunSayisi,
                    DestekIstenenHayvanSayisi = I.DestekIstenenHayvanSayisi,
                    Otenazi = I.Otenazi,
                    HayvanAgirlik = I.HayvanAgirlik,
                    DeneyHayvaniCinsiyet = I.DeneyHayvaniCinsiyet,
                    OtenaziUcreti = I.OtenaziUcreti,
                    OtenaziToplamUcreti = I.OtenaziToplamUcreti,
                    HayvanFiyati = I.HayvanFiyati,
                    GunlukBakimUcreti = I.GunlukBakimUcreti,
                   // DestekTalepTurleriJson = JsonConvert.DeserializeObject<DestekTalepTurleriJsonDto>(I.DestekTalepTurleriJson),
                     DestekTalepTurleriJson = JsonConvert.DeserializeObject(I.DestekTalepTurleriJson),
                   //DestekTalepTurleriJson = I.DestekTalepTurleriJson,
                    ToplamFiyat = I.ToplamFiyat,
                    AppUserId = I.AppUserId,
                    Id=I.Id,

                })
                .OrderByDescending(I => I.Id)
                .Where(I => I.AppUserId == userID )
                //.Where(I => I.SiparislerID == 0)
                .ToList();
        }


         public async   Task<List<ShopCartAjaxListDto>>  GetCartSiparislerIDList(int SiparislerID)
        {
            StncCMSContext context =  new StncCMSContext();
            return await context.StShoppingCartItem.Select(I => new ShopCartAjaxListDto()
            {
                HayvaniIrkFiyatID = I.HayvaniIrkFiyatID,
                HayvanIrkAdi = I.HayvanIrkAdi,
                HayvanAdi = I.HayvanAdi,
                HayvanIrkFiyatTipYasBilgisi = I.HayvanIrkFiyatTipYasBilgisi,
                IstenenHayvanSayisi = I.IstenenHayvanSayisi,
                BakimDestegiGunSayisi = I.BakimDestegiGunSayisi,
                DestekIstenenHayvanSayisi = I.DestekIstenenHayvanSayisi,
                Otenazi = I.Otenazi,
                HayvanAgirlik = I.HayvanAgirlik,
                DeneyHayvaniCinsiyet = I.DeneyHayvaniCinsiyet,
                OtenaziUcreti = I.OtenaziUcreti,
                OtenaziToplamUcreti = I.OtenaziToplamUcreti,
                HayvanFiyati = I.HayvanFiyati,
                GunlukBakimUcreti = I.GunlukBakimUcreti,
                //  DestekTalepTurleriJson = JsonConvert.DeserializeObject(I.DestekTalepTurleriJson),
                DestekTalepTurleriJsonRead=I.DestekTalepTurleriJson,
                ToplamFiyat = I.ToplamFiyat,
                AppUserId = I.AppUserId,
                SiparislerID=  I.SiparislerID,
                Id = I.Id,

            }).OrderByDescending(I => I.Id)
            .Where(I => I.SiparislerID == SiparislerID)
            .ToListAsync();
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


        public void UpdateSiparislerID(int id, int value)
        {
             StShoppingCartItem opt = _context.StShoppingCartItem.Where(I => I.Id == id).FirstOrDefault();
              opt.SiparislerID = value;
              _context.SaveChanges();



            // StShoppingCartItem result = _context.StShoppingCartItem.SingleOrDefault(I => I.Id == id);
            //if (result != null)
            //{
            //    result.SiparislerID = value;
            //    _context.SaveChanges();
            //}
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
