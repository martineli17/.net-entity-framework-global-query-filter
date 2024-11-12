using GlobalQueryFilter.Data.Base;
using GlobalQueryFilter.Domain.Contracts.Repositories;
using GlobalQueryFilter.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlobalQueryFilter.Data.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly DbSet<Invoice> _invoices;
        public InvoiceRepository(IDatabaseContext databaseContext)
        {
            _invoices = databaseContext.Set<Invoice>();
        }

        public async Task AddAsync(Invoice invoice, CancellationToken cancellationToken)
        {
            await _invoices.AddAsync(invoice, cancellationToken);
        }

        public async Task<IReadOnlyList<Invoice>> GetByOwnerAsync(string owner, CancellationToken cancellationToken)
        {
            return await _invoices.ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<Invoice>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _invoices.IgnoreQueryFilters().ToListAsync(cancellationToken);
        }
    }
}
