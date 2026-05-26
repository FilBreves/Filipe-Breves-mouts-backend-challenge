using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{
    public class GetSaleResponse
    {
        public Guid Id { get; set; }
        public int SaleNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime SaleDate { get; }
        public string BranchId { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerAddress { get; set; }
        public IEnumerable<SaleProduct> Products { get; set; }

        public bool IsCancelled { get; set; } = false;
    }
}
