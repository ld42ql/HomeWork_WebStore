using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.Account;
using WebStore.Domain.Entities;
using WebStore.Interfaces;

namespace WebStore.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;
        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        public IActionResult Details()
        {
            return View("Cart", cartService.TransformCart());
        }
        public IActionResult DecrementFromCart(int id)
        {
            cartService.DecrementFromCart(id);
            return RedirectToAction("Details");
        }
        public IActionResult RemoveFromCart(int id)
        {
            cartService.RemoveFromCart(id);
            return RedirectToAction("Details");
        }
        public IActionResult RemoveAll()
        {
            cartService.RemoveAll();
            return RedirectToAction("Details");
        }
        public IActionResult AddToCart(int id, string returnUrl, int? count)
        {
            if (count != null)
            {
                for (int i = 1; i <= count; i++)
                {
                    cartService.AddToCart(id);
                }
            }
            cartService.AddToCart(id);

            return Redirect(returnUrl);
        }
    }
}
