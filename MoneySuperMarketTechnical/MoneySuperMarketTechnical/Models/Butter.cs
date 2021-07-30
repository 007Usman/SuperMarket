using MoneySuperMarketTechnical.Models.Base;

namespace MoneySuperMarketTechnical.Models
{
    public class Butter : BaseProduct
    {
        public Butter(string productName = "Butter", decimal price = 0.80m) : base(productName, price)
        {
        }
    }
}
