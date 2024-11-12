using GlobalQueryFilter.Domain.Contracts.Common;

namespace GlobalQueryFilter.Data.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseContext _databaseContext;

        public UnitOfWork(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<bool> CommitAsync(CancellationToken cancellationToken)
        {
           return await _databaseContext.CommmitAsync(cancellationToken) > 0;
        }
    }
}
