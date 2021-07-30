using MoneySuperMarketTechnical.Models.Base;
using MoneySuperMarketTechnical.Services.Base;

namespace MoneySuperMarketTechnical.Services
{
    public class ShoppingCart : IShoppingCart
    {
        public IProduct Product { get; }
        public int Quantity { get; }
        public decimal Price { get; private set; }

        public ShoppingCart(IProduct product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = Product.Price * Quantity;
        }

        public decimal UpdateCart(decimal discount, int quantity = 0)
        {
            int discountedQuantity = quantity < Quantity ? quantity : Quantity;

            Price = (Product.Price * discountedQuantity * discount) + (Product.Price * (Quantity - discountedQuantity));

            return Price;
        }
    }
}
