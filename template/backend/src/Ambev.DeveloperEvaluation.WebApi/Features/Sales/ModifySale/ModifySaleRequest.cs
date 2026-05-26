using Ambev.DeveloperEvaluation.Domain.Entities;


namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ModifySale
{
    public class ModifySaleRequest
    {
        public string BranchId { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerAddress { get; set; }
        public IEnumerable<SaleProduct> Products { get; set; }
    }
}
