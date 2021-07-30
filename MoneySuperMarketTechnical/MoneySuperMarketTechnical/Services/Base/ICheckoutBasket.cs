using System.Collections.Generic;

namespace MoneySuperMarketTechnical.Services.Base
{
    public interface ICheckoutBasket
    {
        List<IShoppingCart> ShoppingBasket { get; }

        void AddProduct(IShoppingCart product);
        decimal GetTotalCost();
    }
}
