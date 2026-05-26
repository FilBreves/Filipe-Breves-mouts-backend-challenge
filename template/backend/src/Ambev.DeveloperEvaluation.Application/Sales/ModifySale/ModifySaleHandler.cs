using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.Sales.ModifySale;


public class ModifySaleHandler : IRequestHandler<ModifySaleCommand, ModifySaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;


    public ModifySaleHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }


    public async Task<ModifySaleResult> Handle(ModifySaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new ModifySaleCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);




        var sale = await _saleRepository.GetByIdAsync(command.Id, cancellationToken);

        sale!.Products = command.Products;

        sale.CalculateDiscountAndTotalAmount();


        _saleRepository.ModifySaleNoSaveAsync(sale, cancellationToken);

        _saleRepository.ModifySaleProductsNoSaveAsync(sale.Products, cancellationToken);

        await _saleRepository.SaveSaleAsync(cancellationToken);

        var result = _mapper.Map<ModifySaleResult>(sale);
        return result;
    }

    
}
