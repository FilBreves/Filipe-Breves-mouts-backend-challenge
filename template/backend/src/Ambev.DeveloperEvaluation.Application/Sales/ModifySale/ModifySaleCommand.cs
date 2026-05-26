using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.ModifySale;


public class ModifySaleCommand : IRequest<ModifySaleResult>
{
    public Guid Id { get; set; }
    public IEnumerable<SaleProduct> Products { get; set; }



    public ValidationResultDetail Validate()
    {
        var validator = new ModifySaleCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}