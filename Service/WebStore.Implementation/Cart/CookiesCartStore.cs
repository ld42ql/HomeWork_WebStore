using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WebStore.Domain.Models.Cart;
using WebStore.Interfaces;

namespace WebStore.Implementation.Cart
{
   public class CookiesCartStore : ICartStore
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly string cartName;

        public CookiesCartStore(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.cartName = "cart" + 
                (this.httpContextAccessor.HttpContext.User.Identity.IsAuthenticated ?
                this.httpContextAccessor.HttpContext.User.Identity.Name : "");
        }

        public Domain.Models.Cart.Cart Cart
        {
            get
            {
                var cookie = httpContextAccessor.HttpContext.Request.Cookies[cartName];
                string json;
                Domain.Models.Cart.Cart cart;

                if (cookie == null)
                {
                    cart = new Domain.Models.Cart.Cart { Items = new List<CartItem>() };
                    json = JsonConvert.SerializeObject(cart);

                    httpContextAccessor.HttpContext.Response.Cookies
                        .Append(cartName, json, new CookieOptions()
                        {
                            Expires = DateTime.Now.AddDays(1)
                        });
                    return cart;
                }

                json = cookie;
                cart = JsonConvert.DeserializeObject<Domain.Models.Cart.Cart>(json);

                httpContextAccessor.HttpContext.Response.Cookies.Delete(cartName);

                httpContextAccessor.HttpContext.Response.Cookies
                    .Append(cartName, json, new CookieOptions()
                    {
                        Expires = DateTime.Now.AddDays(1)
                    });

                return cart;
            }

            set
            {
                var json = JsonConvert.SerializeObject(value);

                httpContextAccessor.HttpContext.Response.Cookies.Delete(cartName);
                httpContextAccessor.HttpContext.Response.Cookies
                    .Append(cartName, json, new CookieOptions()
                    {
                        Expires = DateTime.Now.AddDays(1)
                    });
            }
        }
    }
}
