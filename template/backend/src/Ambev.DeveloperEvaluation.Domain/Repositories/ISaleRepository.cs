using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;


public interface ISaleRepository
{

    Task<Sale> CreateSaleNoSaveAsync(Sale sale, CancellationToken cancellationToken = default);

    Task CreateSaleProductsNoSaveAsync(IEnumerable<SaleProduct> saleProducts, CancellationToken cancellationToken = default);
    Task SaveSaleAsync(CancellationToken cancellationToken = default);

    Task<List<SaleProduct>?> GetSaleProductsByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);


    Task<bool> CancelSaleAsync(Guid id, CancellationToken cancellationToken = default);

    Sale ModifySaleNoSaveAsync(Sale sale, CancellationToken cancellationToken = default);

    void ModifySaleProductsNoSaveAsync(IEnumerable<SaleProduct> saleProducts, CancellationToken cancellationToken = default);

}
