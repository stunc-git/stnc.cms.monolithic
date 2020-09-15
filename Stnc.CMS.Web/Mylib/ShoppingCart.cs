using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Stnc.CMS.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Stnc.CMS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stnc.CMS.Web.Mylib
{
    public class ShoppingCart
    {
        private readonly StncCMSContext _context;

    public ShoppingCart(StncCMSContext context)
        {
            _context = context;
        }

        public string Id { get; set; }
        public IEnumerable<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<StncCMSContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);
            return new ShoppingCart(context) { Id = cartId };
        }

        public bool AddToCart(Cart cart, int amount)
        {
            if (cart.InStock == 0 || amount == 0)
            {
                return false;
            }

            var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(
                s => s.Cart.Id == cart.Id && s.ShoppingCartId == Id);
            var isValidAmount = true;
            if (shoppingCartItem == null)
            {
                if (amount > cart.InStock)
                {
                    isValidAmount = false;
                }
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = Id,
                    Cart = cart,
                    Amount = Math.Min(cart.InStock, amount)
                };
                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                if (cart.InStock - shoppingCartItem.Amount - amount >= 0)
                {
                    shoppingCartItem.Amount += amount;
                }
                else
                {
                    shoppingCartItem.Amount += (cart.InStock - shoppingCartItem.Amount);
                    isValidAmount = false;
                }
            }

            _context.SaveChanges();
            return isValidAmount;
        }

        public int RemoveFromCart(Cart cart)
        {
            var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(
                s => s.Cart.Id == cart.Id && s.ShoppingCartId == Id);
            int localAmount = 0;
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _context.SaveChanges();
            return localAmount;
        }

        public IEnumerable<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                       (ShoppingCartItems = _context.ShoppingCartItems.Where(c => c.ShoppingCartId == Id).Include(s => s.Cart));
        }

        public void ClearCart()
        {
            var cartItems = _context
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == Id);

            _context.ShoppingCartItems.RemoveRange(cartItems);
            _context.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            return _context.ShoppingCartItems.Where(c => c.ShoppingCartId == Id)
                .Select(c => c.Cart.Price * c.Amount).Sum();
        }
    }
}
