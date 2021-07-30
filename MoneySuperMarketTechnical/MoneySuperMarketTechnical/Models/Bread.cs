using MoneySuperMarketTechnical.Models.Base;

namespace MoneySuperMarketTechnical.Models
{
    public class Bread : BaseProduct
    {
        public Bread(string productName = "Bread", decimal price = 1.00m) : base(productName, price)
        {
        }
    }
}
