using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Cart;

namespace WebStore.Interfaces
{
   public interface ICartStore
    {
        Cart Cart { get; set; }
    }
}
