using System;
using System.Collections.Generic;
using MoneySuperMarketTechnical.Helpers;
using MoneySuperMarketTechnical.Helpers.Base;
using MoneySuperMarketTechnical.Models;
using MoneySuperMarketTechnical.Services;
using MoneySuperMarketTechnical.Services.Base;

namespace MoneySuperMarketTechnical
{
    class Program
    {
        static void Main()
        {
            List<IDiscountedProduct> discounts = new List<IDiscountedProduct>();
            discounts.Add(new ButterDiscount());
            discounts.Add(new MilkDiscount());

            ICheckoutBasket basket = new CheckoutBasket(discounts);
            basket.AddProduct(new ShoppingCart(new Butter(), 2));
            basket.AddProduct(new ShoppingCart(new Bread(), 1));
            basket.AddProduct(new ShoppingCart(new Milk(), 8));

            decimal total = basket.GetTotalCost();

            Console.WriteLine(total);
        }
    }
}
