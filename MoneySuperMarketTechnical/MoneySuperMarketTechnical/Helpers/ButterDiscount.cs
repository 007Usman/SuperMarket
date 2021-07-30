using System.Linq;
using MoneySuperMarketTechnical.Helpers.Base;
using MoneySuperMarketTechnical.Models;
using MoneySuperMarketTechnical.Services.Base;

namespace MoneySuperMarketTechnical.Helpers
{
    public class ButterDiscount : IDiscountedProduct
    {
        private const decimal DiscountPercentage = 0.5m;
        private const int MinProductQualifier = 2;
        private const int NumberOfDiscount = 1;

        public void ApplyDiscount(ICheckoutBasket checkout)
        {
            int totalButterCount = checkout.ShoppingBasket
                .Where(x => x.Product is Butter)
                .Select(x => x.Quantity)
                .Sum();

            int discountedBreads = 0;

            foreach (IShoppingCart basket in checkout.ShoppingBasket)
            {
                if (basket.Product is Bread && totalButterCount >= MinProductQualifier && discountedBreads < NumberOfDiscount)
                {
                    basket.UpdateCart(DiscountPercentage, NumberOfDiscount - discountedBreads);

                    discountedBreads++;
                }
            }
        }
    }
}
