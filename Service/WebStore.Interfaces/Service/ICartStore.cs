using WebStore.Domain.Models.Cart;

namespace WebStore.Interfaces
{
    public interface ICartStore
    {
        Cart Cart { get; set; }
    }
}
