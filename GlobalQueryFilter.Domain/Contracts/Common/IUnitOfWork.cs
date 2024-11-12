using System.Threading;
using System.Threading.Tasks;

namespace GlobalQueryFilter.Domain.Contracts.Common
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync(CancellationToken cancellationToken);
    }
}
