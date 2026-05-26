using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

/// <summary>
/// Profile for mapping between User entity and CreateUserResponse
/// </summary>
public class CancelSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser operation
    /// </summary>
    public CancelSaleProfile()
    {
        CreateMap<CreateUserCommand, User>();
        CreateMap<User, CreateUserResult>();
    }
}
