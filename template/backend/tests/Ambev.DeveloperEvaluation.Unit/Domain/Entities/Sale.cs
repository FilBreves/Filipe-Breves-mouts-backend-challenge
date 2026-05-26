using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class SaleTests
    {
        [Fact]
        public void CalculateDiscount_ShouldThrow_WhenQuantityIsZero()
        {
            var sale = new Sale
            {
                Products = new List<SaleProduct>
            {
                new SaleProduct { Quantity = 0, UnitPrice = 10 }
            }
            };

            Assert.Throws<ArgumentException>(() => sale.CalculateDiscountAndTotalAmount());
        }

        [Fact]
        public void CalculateDiscount_ShouldThrow_WhenQuantityGreaterThan20()
        {
            var sale = new Sale
            {
                Products = new List<SaleProduct>
            {
                new SaleProduct { Quantity = 25, UnitPrice = 10 }
            }
            };

            Assert.Throws<ArgumentException>(() => sale.CalculateDiscountAndTotalAmount());
        }

        [Fact]
        public void CalculateDiscount_ShouldApply10PercentDiscount_WhenQuantityBetween4And9()
        {
            var sale = new Sale
            {
                Products = new List<SaleProduct>
            {
                new SaleProduct { Quantity = 5, UnitPrice = 100 }
            }
            };

            sale.CalculateDiscountAndTotalAmount();

            Assert.Equal(0.9M, sale.Products.FirstOrDefault().Discount);
            Assert.Equal(5 * 100 * 0.9M, sale.Products.FirstOrDefault().TotalAmount);
        }

        [Fact]
        public void CalculateDiscount_ShouldApply20PercentDiscount_WhenQuantityBetween10And20()
        {
            var sale = new Sale
            {
                Products = new List<SaleProduct>
            {
                new SaleProduct { Quantity = 10, UnitPrice = 50 }
            }
            };

            sale.CalculateDiscountAndTotalAmount();

            Assert.Equal(0.8M, sale.Products.FirstOrDefault().Discount);
            Assert.Equal(10 * 50 * 0.8M, sale.Products.FirstOrDefault().TotalAmount);
        }

        [Fact]
        public void CalculateDiscount_ShouldNotApplyDiscount_WhenQuantityLessThan4()
        {
            var sale = new Sale
            {
                Products = new List<SaleProduct>
            {
                new SaleProduct { Quantity = 2, UnitPrice = 20 }
            }
            };

            sale.CalculateDiscountAndTotalAmount();

            Assert.Equal(0M, sale.Products.FirstOrDefault().Discount); 
            Assert.Equal(2 * 20, sale.Products.FirstOrDefault().TotalAmount); 
        }
    }

}
