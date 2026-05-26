
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;


public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;


    public CreateSaleHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }


    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);


        var sale = _mapper.Map<Sale>(command);


        var random = new Random().Next(1000, 9999); 
        sale.SaleNumber = int.Parse((DateTime.UtcNow.ToString("yyMMddHHmmss") + random.ToString()));

        sale.CalculateDiscountAndTotalAmount();

        var createdSale = await _saleRepository.CreateSaleNoSaveAsync(sale, cancellationToken);
        foreach (var item in sale.Products)
        {
            item.SaleId = createdSale.Id;
        }

        await _saleRepository.CreateSaleProductsNoSaveAsync(sale.Products, cancellationToken);

        await _saleRepository.SaveSaleAsync(cancellationToken);

        var result = _mapper.Map<CreateSaleResult>(createdSale);
        return result;
    }

  
}
