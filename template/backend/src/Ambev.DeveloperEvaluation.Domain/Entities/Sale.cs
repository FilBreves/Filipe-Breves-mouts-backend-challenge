using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Common;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale: BaseEntity
    {
        public Sale()
        {
            SaleDate = DateTime.UtcNow;
        }
        public int SaleNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime SaleDate { get; }
        public string BranchId { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerAddress { get; set; }
        public IEnumerable<SaleProduct> Products { get; set; }

        public bool IsCancelled { get; set; } = false;


        public void CalculateDiscountAndTotalAmount()
        {
            foreach (var product in Products)
            {
                if (product.Quantity <= 0)
                    throw new ArgumentException("Product quantity can't be zero");

                if (product.Quantity > 20)
                    throw new ArgumentException("Product quantity can't be more than 20.");

                if (product.Quantity >= 4 && product.Quantity < 10)
                {
                    product.Discount = 0.9M;
                    product.TotalAmount = product.Quantity * product.UnitPrice * product.Discount;
                    continue;
                }

                if (product.Quantity >= 10 && product.Quantity <= 20)
                {
                    product.Discount = 0.8M;
                    product.TotalAmount = product.Quantity * product.UnitPrice * product.Discount;
                    continue;
                }

                product.Discount = 0;
                product.TotalAmount = product.Quantity * product.UnitPrice;

            }

            TotalAmount = Products.Where(x => x.IsCanceled = false).Sum(x => x.TotalAmount);
        }
    }
}
