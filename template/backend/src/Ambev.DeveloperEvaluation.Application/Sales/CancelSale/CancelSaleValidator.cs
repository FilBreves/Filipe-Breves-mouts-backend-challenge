using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;


public class CancelSaleCommandValidator : AbstractValidator<CancelSaleCommand>
{

    public CancelSaleCommandValidator()
    {
        //RuleFor(user => user.Email).SetValidator(new EmailValidator());
        //RuleFor(user => user.Username).NotEmpty().Length(3, 50);
        //RuleFor(user => user.Password).SetValidator(new PasswordValidator());
        //RuleFor(user => user.Phone).Matches(@"^\+?[1-9]\d{1,14}$");
        //RuleFor(user => user.Status).NotEqual(UserStatus.Unknown);
        //RuleFor(user => user.Role).NotEqual(UserRole.None);
    }
}