using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Stnc.CMS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stnc.CMS.DataAccess.ShoppingCartLib
{
    public class ShoppingCart
    {
        private readonly StncCMSContext _context;

        public ShoppingCart(StncCMSContext context)
        {
            _context = context;
        }

        public string Id { get; set; }
        public IEnumerable<StShoppingCartItem> StShoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<StncCMSContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);
            return new ShoppingCart(context) { Id = cartId };
        }

        public bool AddToCart(StCart cart, int amount)
        {
            if (cart.InStock == 0 || amount == 0)
            {
                return false;
            }

            var shoppingCartItem = _context.StShoppingCartItem.SingleOrDefault(s => s.Cart.Id == cart.Id && s.ShoppingCartId == Id);
            var isValidAmount = true;
            if (shoppingCartItem == null)
            {
                if (amount > cart.InStock)
                {
                    isValidAmount = false;
                }
                shoppingCartItem = new StShoppingCartItem
                {
                    ShoppingCartId = Id,
                    Cart = cart,
                    ToplamFiyat = Math.Min(cart.InStock, amount)
                };
                _context.StShoppingCartItem.Add(shoppingCartItem);
            }
            else
            {
                if (cart.InStock - shoppingCartItem.ToplamFiyat - amount >= 0)
                {
                    shoppingCartItem.ToplamFiyat += amount;
                }
                else
                {
                    shoppingCartItem.ToplamFiyat += (cart.InStock - shoppingCartItem.ToplamFiyat);
                    isValidAmount = false;
                }
            }

            _context.SaveChanges();
            return isValidAmount;
        }

        public decimal RemoveFromCart(StCart cart)
        {
            var shoppingCartItem = _context.StShoppingCartItem.SingleOrDefault(s => s.Cart.Id == cart.Id && s.ShoppingCartId == Id);
            decimal localAmount = 0;
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.ToplamFiyat > 1)
                {
                    shoppingCartItem.ToplamFiyat--;
                    localAmount = shoppingCartItem.ToplamFiyat;
                }
                else
                {
                    _context.StShoppingCartItem.Remove(shoppingCartItem);
                }
            }
            _context.SaveChanges();
            return localAmount;
        }

        public IEnumerable<StShoppingCartItem> GetShoppingCartItems()
        {
            return StShoppingCartItems ??
                   (StShoppingCartItems = _context.StShoppingCartItem.Where(c => c.ShoppingCartId == Id)
                       .Include(s => s.Cart));
        }

        public void ClearCart()
        {
            var cartItems = _context
                .StShoppingCartItem
                .Where(cart => cart.ShoppingCartId == Id);

            _context.StShoppingCartItem.RemoveRange(cartItems);
            _context.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            return _context.StShoppingCartItem.Where(c => c.ShoppingCartId == Id).Select(c => c.Cart.Price * c.ToplamFiyat).Sum();
        }
    }
}