using System;
namespace MoneySuperMarketTechnical.Models.Base
{
    public abstract class BaseProduct : IProduct
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        protected BaseProduct(string productName, decimal price)
        {
            ProductName = productName ?? throw new ArgumentNullException(nameof(productName));
            Price = price;
        }
    }
}
