using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequest
    {
        public string BranchId { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerAddress { get; set; }
        public IEnumerable<SaleProduct> Products { get; set; }
    }
}
