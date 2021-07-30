using MoneySuperMarketTechnical.Models.Base;

namespace MoneySuperMarketTechnical.Models
{
    public class Milk : BaseProduct
    {
        public Milk(string productName = "Milk", decimal price = 1.15m) : base(productName, price)
        {
        }
    }
}
