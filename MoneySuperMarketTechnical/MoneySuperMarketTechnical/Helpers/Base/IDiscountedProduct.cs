using MoneySuperMarketTechnical.Services.Base;

namespace MoneySuperMarketTechnical.Helpers.Base
{
    public interface IDiscountedProduct
    {
        void ApplyDiscount(ICheckoutBasket checkout);
    }
}
