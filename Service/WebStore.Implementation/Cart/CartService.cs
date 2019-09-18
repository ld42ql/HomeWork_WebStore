using System.Collections.Generic;
using System.Linq;
using WebStore.Domain.Models.Cart;
using WebStore.Domain.Models.Catalogs;
using WebStore.Domain.Models.Filters;
using WebStore.Interfaces;

namespace WebStore.Implementation.Cart
{
    public class CartService : ICartService
    {
    
        private readonly IProductData productData;
        private readonly ICartStore cartStore;

        public CartService(IProductData productData, ICartStore cartStore)
        {
            this.productData = productData;
            this.cartStore = cartStore;
        }

        /// <summary>
        /// Добавить товар в корзину, если товар есть то увеличить количество
        /// </summary>
        /// <param name="id"></param>
        public void AddToCart(int id)
        {
            var cart = cartStore.Cart;
            var item = cart.Items.FirstOrDefault(x => x.ProductId == id);

            if (item != null)
                item.Quantity++;
            else
                cart.Items.Add(new CartItem { ProductId = id, Quantity = 1 });

            cartStore.Cart = cart;
        }


        /// <summary>
        /// Уменьшение количества товара в корзине
        /// </summary>
        /// <param name="id"></param>
        public void DecrementFromCart(int id)
        {
            var cart = cartStore.Cart;

            var item = cart.Items.FirstOrDefault(x => x.ProductId == id);

            if (item?.Quantity > 0)
                if (item != null)
                    item.Quantity--;

            if (item?.Quantity == 0)
                cart.Items.Remove(item);

            cartStore.Cart = cart;
        }

        /// <summary>
        /// Удалить товар из корзины
        /// </summary>
        /// <param name="id"></param>
        public void RemoveFromCart(int id)
        {
            var cart = cartStore.Cart;
            var item = cart.Items.FirstOrDefault(x => x.ProductId == id);
            if (item != null)
            {
                cart.Items.Remove(item);
            }
            cartStore.Cart = cart;
        }

        /// <summary>
        /// Очистить корзину
        /// </summary>
        public void RemoveAll()
        {
            cartStore.Cart = new Domain.Models.Cart.Cart { Items = new List<CartItem>() };
        }

       /// <summary>
       /// Представления корзины
       /// </summary>
       /// <returns></returns>
        public CartViewModel TransformCart()
        {
            var products = productData.GetProducts(new ProductFilter()
            {
                Ids = cartStore.Cart.Items.Select(i => i.ProductId).ToList()
            }).Select(p => new ProductViewModel()
            {
                Id = p.Id,
                ImageUrl = p.ImageUrl,
                Name = p.Name,
                Order = p.Order,
                Price = p.Price,
                Brand = p.Brand != null ? p.Brand.Name : string.Empty
            }).ToList();

            var cartView = new CartViewModel
            {
                Items = cartStore.Cart.Items.ToDictionary(x => products.First(y => y.Id == x.ProductId), x => x.Quantity)
            };

            return cartView;

        }
    }
}
