using GlobalQueryFilter.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GlobalQueryFilter.Domain.Contracts.Repositories
{
    public interface IInvoiceRepository
    {
        Task AddAsync(Invoice invoice, CancellationToken cancellationToken);
        Task<IReadOnlyList<Invoice>> GetByOwnerAsync(string owner, CancellationToken cancellationToken);
        Task<IReadOnlyList<Invoice>> GetAllAsync(CancellationToken cancellationToken);
    }
}
