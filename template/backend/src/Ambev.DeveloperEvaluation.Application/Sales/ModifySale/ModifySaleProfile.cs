using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.ModifySale;

/// <summary>
/// Profile for mapping between User entity and ModifyUserResponse
/// </summary>
public class ModifySaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ModifyUser operation
    /// </summary>
    public ModifySaleProfile()
    {
        CreateMap<ModifySaleCommand, Sale>();
        CreateMap<Sale, ModifySaleResult>();
    }
}
