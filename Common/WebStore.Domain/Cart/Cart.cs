using System.Collections.Generic;
using System.Linq;

namespace WebStore.Domain.Cart
{
    public class Cart
    {
        public IList<CartItem> Items { get; set; }

        public int ItemsCount
        {
            get
            {
                return Items?.Sum(x => x.Quantity) ?? 0;
            }
        }

    }
}
