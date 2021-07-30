using System.Linq;
using MoneySuperMarketTechnical.Helpers.Base;
using MoneySuperMarketTechnical.Models;
using MoneySuperMarketTechnical.Services.Base;

namespace MoneySuperMarketTechnical.Helpers
{
    public class MilkDiscount : IDiscountedProduct
    {
        private const decimal DiscountPercentage = 0;
        private const int MinProductQualifier = 3;

        public void ApplyDiscount(ICheckoutBasket checkout)
        {
            int totalMilkCount = checkout.ShoppingBasket
                .Where(i => i.Product is Milk)
                .Select(i => i.Quantity)
                .Sum();

            int calculatedFreeMilk = totalMilkCount / MinProductQualifier;
            int discountedMilks = 0;

            foreach (IShoppingCart basket in checkout.ShoppingBasket)
            {
                if (basket.Product is Milk && totalMilkCount >= MinProductQualifier && discountedMilks < calculatedFreeMilk)
                {
                    int freeMilkToIssue = basket.Quantity / MinProductQualifier;

                    if (freeMilkToIssue == 0)
                    {
                        freeMilkToIssue = 1;
                    }

                    basket.UpdateCart(DiscountPercentage, freeMilkToIssue);

                    discountedMilks += freeMilkToIssue;
                }
            }
        }
    }
}
