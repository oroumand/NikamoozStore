using NikamoozStore.Core.Domain.Products;

namespace NikamoozStore.Core.Domain.Carts
{
    public class CartLine
    {
        public int CartLineID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
