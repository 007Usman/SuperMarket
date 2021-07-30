using MoneySuperMarketTechnical.Models.Base;

namespace MoneySuperMarketTechnical.Services.Base
{
    public interface IShoppingCart
    {
        IProduct Product { get; }
        int Quantity { get; }
        decimal Price { get; }

        decimal UpdateCart(decimal discountMultiplicator, int dicountedQuantity = 0);
    }
}
