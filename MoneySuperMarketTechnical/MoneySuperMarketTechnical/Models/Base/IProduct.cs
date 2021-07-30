namespace MoneySuperMarketTechnical.Models.Base
{
    public interface IProduct
    {
        string ProductName { get; set; }
        decimal Price { get; set; }
    }
}
