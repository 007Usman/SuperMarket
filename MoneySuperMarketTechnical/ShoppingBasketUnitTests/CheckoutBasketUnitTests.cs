using System.Collections.Generic;
using MoneySuperMarketTechnical.Helpers;
using MoneySuperMarketTechnical.Helpers.Base;
using MoneySuperMarketTechnical.Models;
using MoneySuperMarketTechnical.Services;
using MoneySuperMarketTechnical.Services.Base;
using Xunit;

namespace ShoppingBasketUnitTests
{
    public class CheckoutBasketUnitTests
    {
        private readonly List<IDiscountedProduct> _discountProduct = new List<IDiscountedProduct>();
        private ICheckoutBasket _checkoutBasket;

        public CheckoutBasketUnitTests()
        {
            _discountProduct.Add(new ButterDiscount());
            _discountProduct.Add(new MilkDiscount());
        }

        [Fact]
        public void GetTotalCost_PriceCalculated_WithoutDiscount()
        {
            // Arrange
            _checkoutBasket = new CheckoutBasket(null);

            _checkoutBasket.AddProduct(new ShoppingCart(new Milk(), 8));
            _checkoutBasket.AddProduct(new ShoppingCart(new Bread(), 1));
            _checkoutBasket.AddProduct(new ShoppingCart(new Butter(), 2));

            // Act
            decimal actual = _checkoutBasket.GetTotalCost();

            // Assert
            Assert.Equal(11.80m, actual);
        }

        [Fact]
        public void GetTotalCost_PriceCalculated_NoDiscountGiven()
        {
            // Arrange
            _checkoutBasket = new CheckoutBasket(_discountProduct);

            _checkoutBasket.AddProduct(new ShoppingCart(new Milk(), 2));
            _checkoutBasket.AddProduct(new ShoppingCart(new Bread(), 2));

            // Act
            decimal actual = _checkoutBasket.GetTotalCost();

            // Assert
            Assert.Equal(4.30m, actual);
        }

        [Fact]
        public void GetTotalCost_PriceCalculated_DiscountedBreadGiven()
        {
            // Arrange
            _checkoutBasket = new CheckoutBasket(_discountProduct);

            _checkoutBasket.AddProduct(new ShoppingCart(new Butter(), 2));
            _checkoutBasket.AddProduct(new ShoppingCart(new Bread(), 2));

            // Act
            decimal actual = _checkoutBasket.GetTotalCost();

            // Assert
            Assert.Equal(3.10m, actual);
        }

        [Fact]
        public void GetTotalCost_PriceCalculated_DiscountedBreadGivenAgain()
        {
            // Arrange
            _checkoutBasket = new CheckoutBasket(_discountProduct);

            _checkoutBasket.AddProduct(new ShoppingCart(new Butter(), 1));
            _checkoutBasket.AddProduct(new ShoppingCart(new Butter(), 1));
            _checkoutBasket.AddProduct(new ShoppingCart(new Bread(), 1));
            _checkoutBasket.AddProduct(new ShoppingCart(new Bread(), 1));

            // Act
            decimal actual = _checkoutBasket.GetTotalCost();

            // Assert
            Assert.Equal(3.10m, actual);
        }

        [Fact]
        public void GetTotalCost_PriceCalculated_FreeMilkDiscounted()
        {
            // Arrange
            _checkoutBasket = new CheckoutBasket(_discountProduct);

            _checkoutBasket.AddProduct(new ShoppingCart(new Milk(), 4));

            // Act
            decimal actual = _checkoutBasket.GetTotalCost();

            // Assert
            Assert.Equal(3.45m, actual);
        }

        [Fact]
        public void GetTotalCost_PriceCalculated_FreeMilkDiscountedAgain()
        {
            // Arrange
            _checkoutBasket = new CheckoutBasket(_discountProduct);

            _checkoutBasket.AddProduct(new ShoppingCart(new Milk(), 1));
            _checkoutBasket.AddProduct(new ShoppingCart(new Milk(), 1));
            _checkoutBasket.AddProduct(new ShoppingCart(new Milk(), 1));
            _checkoutBasket.AddProduct(new ShoppingCart(new Milk(), 1));

            // Act
            decimal actual = _checkoutBasket.GetTotalCost();

            // Assert
            Assert.Equal(3.45m, actual);
        }

        [Fact]
        public void GetTotalCost_PriceCalculated_DiscountedMilkAndBread()
        {
            // Arrange
            _checkoutBasket = new CheckoutBasket(_discountProduct);

            _checkoutBasket.AddProduct(new ShoppingCart(new Butter(), 2));
            _checkoutBasket.AddProduct(new ShoppingCart(new Bread(), 1));
            _checkoutBasket.AddProduct(new ShoppingCart(new Milk(), 8));

            // Act
            decimal actual = _checkoutBasket.GetTotalCost();

            // Assert
            Assert.Equal(9m, actual);
        }

        [Fact]
        public void GetTotalCost_PriceCalculated_DiscountedMilkAndBreadAgain()
        {
            // Arrange
            _checkoutBasket = new CheckoutBasket(_discountProduct);

            _checkoutBasket.AddProduct(new ShoppingCart(new Butter(), 1));
            _checkoutBasket.AddProduct(new ShoppingCart(new Butter(), 1));
            _checkoutBasket.AddProduct(new ShoppingCart(new Bread(), 1));
            _checkoutBasket.AddProduct(new ShoppingCart(new Milk(), 8));

            // Act
            decimal actual = _checkoutBasket.GetTotalCost();

            // Assert
            Assert.Equal(9m, actual);
        }
    }
}
