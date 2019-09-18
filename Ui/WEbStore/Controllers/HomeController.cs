using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.Models.Filters;
using WebStore.Domain.Models.Catalogs;
using WebStore.Interfaces;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        Random random = new Random();

        private readonly IProductData productData;

        public HomeController(IProductData productData) => this.productData = productData;



        public IActionResult Index()
        {
            var products = productData.GetProducts(new ProductFilter
            {
            });
            var model = new CatalogViewModel()
            {
                Products = products.Where(p => p.Id > 6 && p.Id < 13).Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    Name = p.Name,
                    Order = p.Order,
                    Price = p.Price
                } ).OrderBy(p => random.Next(7, 12)).ToList()
            };
            return View(model);
        }

        public IActionResult ProductDetails(int id)
        {
            var product = productData.GetProductById(id);
            if (product == null)
                return View("_NotFound");

            return View(new ProductViewModel
            {
                Id = product.Id,
                ImageUrl = product.ImageUrl,
                Name = product.Name,
                Order = product.Order,
                Price = product.Price,
                Brand = product.Brand != null ? product.Brand.Name : string.Empty
            });

        }

        public IActionResult _NotFound() => View();

        public IActionResult Blog() => View();

        public IActionResult BlogSingle() => View();
        
        public IActionResult Checkout() => View();

        public IActionResult ContactUs() => View();
        
        /// <summary>
        /// Добавлени продукции в страницу "shop"
        /// </summary>
        /// <param name="sectionId">Фильтрация по секциям</param>
        /// <param name="brandId">Фильтрация по брэнду</param>
        /// <returns>Модель продукции</returns>
        public IActionResult Shop(int? sectionId, int? brandId)
        {
            var products = productData.GetProducts(new ProductFilter
            {
                BrandId = brandId,
                SectionId = sectionId
            });
            var model = new CatalogViewModel()
            {
                BrandId = brandId,
                SectionId = sectionId,
                Products = products.Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    Name = p.Name,
                    Order = p.Order,
                    Price = p.Price
                }).OrderBy(p => p.Order).ToList()
            };
            return View(model);
        }
    }


}