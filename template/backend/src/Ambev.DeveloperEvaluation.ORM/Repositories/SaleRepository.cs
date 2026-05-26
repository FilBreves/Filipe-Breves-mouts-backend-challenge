using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;


public class SaleRepository : ISaleRepository
{
    private readonly DefaultContext _context;


    public SaleRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<Sale> CreateSaleNoSaveAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        await _context.Sales.AddAsync(sale, cancellationToken);
        return sale;
    }

    public async Task CreateSaleProductsNoSaveAsync(IEnumerable<SaleProduct> saleProducts, CancellationToken cancellationToken = default)
    {
        await _context.SaleProducts.AddRangeAsync(saleProducts, cancellationToken);
    }

    public async Task SaveSaleAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }


    public async Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Sales.FirstOrDefaultAsync(o=> o.Id == id, cancellationToken);
    }

    public async Task<List<SaleProduct>?> GetSaleProductsByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.SaleProducts.Where(o => o.SaleId == id).ToListAsync();
    }

    public async Task<bool> CancelSaleAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var sale = await GetByIdAsync(id, cancellationToken);
        if (sale == null)
            return false;
        sale.IsCancelled  = true;

        _context.Sales.Update(sale);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public Sale ModifySaleNoSaveAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        _context.Sales.Update(sale);
        return sale;
    }

    public void ModifySaleProductsNoSaveAsync(IEnumerable<SaleProduct> saleProducts, CancellationToken cancellationToken = default)
    {
        _context.SaleProducts.UpdateRange(saleProducts);
    }
}
