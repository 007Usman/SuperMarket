using System.Collections.Generic;
using System.Linq;
using MoneySuperMarketTechnical.Helpers.Base;
using MoneySuperMarketTechnical.Services.Base;

namespace MoneySuperMarketTechnical.Services
{
    public class CheckoutBasket : ICheckoutBasket
    {
        private readonly List<IDiscountedProduct> _discounts;

        public List<IShoppingCart> ShoppingBasket { get; } = new List<IShoppingCart>();

        public CheckoutBasket(List<IDiscountedProduct> discounts)
        {
            _discounts = discounts;
        }

        public void AddProduct(IShoppingCart product)
        {
            ShoppingBasket.Add(product);
        }

        public decimal GetTotalCost()
        {
            if (_discounts != null)
            {
                foreach (var discount in _discounts)
                {
                    discount.ApplyDiscount(this);
                }
            }

            return ShoppingBasket.Select(x => x.Price).Sum();
        }
    }
}
