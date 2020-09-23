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

        public void DeleteFood(int id)
        {
            var food = GetById(id);
            if (food == null)
            {
                throw new ArgumentException();
            }
            _context.Remove(food);
            _context.SaveChanges();
        }

        public void EditFood(StCart food)
        {
            var model = _context.StCart.First(f => f.Id == food.Id);
            _context.Entry<StCart>(model).State = EntityState.Detached;
            _context.Update(food);
            _context.SaveChanges();
        }

        public IEnumerable<StCart> GetAll()
        {
            return _context.StCart.ToList() ;
        }

        public StCart GetById(int id)
        {
            return GetAll().FirstOrDefault(food => food.Id == id);
        }

        //public IEnumerable<StCart> GetFilteredFoods(int id, string searchQuery)
        //{

        //    if (string.IsNullOrEmpty(searchQuery) || string.IsNullOrWhiteSpace(searchQuery))
        //    {
        //        return GetFoodsByCategoryId(id);
        //    }

        //    return GetFilteredFoods(searchQuery).Where(food => food.Category.Id == id);
        //}

        public IEnumerable<StCart> GetFilteredFoods(string searchQuery)
        {
            var queries = string.IsNullOrEmpty(searchQuery) ? null : Regex.Replace(searchQuery, @"\s+", " ").Trim().ToLower().Split(" ");
            if (queries == null)
            {
                return GetPreferred(10);
            }

            return GetAll().Where(item => queries.Any(query => (item.Name.ToLower().Contains(query))));
        }

        //public IEnumerable<StCart> GetFoodsByCategoryId(int categoryId)
        //{
        //    return GetAll().Where(food => food.Category.Id == categoryId);
        //}

        public IEnumerable<StCart> GetPreferred(int count)
        {
            return GetAll().OrderByDescending(food => food.Id).Where(food => food.IsPreferedFood && food.InStock != 0).Take(count);
        }

        public void NewFood(StCart food)
        {
            _context.Add(food);
            _context.SaveChanges();
        }
    }
}
