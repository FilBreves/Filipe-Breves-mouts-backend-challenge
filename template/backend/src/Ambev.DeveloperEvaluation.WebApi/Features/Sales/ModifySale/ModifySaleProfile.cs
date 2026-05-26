using Ambev.DeveloperEvaluation.Application.Sales.ModifySale;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ModifySale;

/// <summary>
/// Profile for mapping between Application and API CreateUser responses
/// </summary>
public class ModifySaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser feature
    /// </summary>
    public ModifySaleProfile()
    {
        CreateMap<ModifySaleRequest, ModifySaleCommand>();
        CreateMap<ModifySaleResult, ModifySaleResponse>();
    }
}
