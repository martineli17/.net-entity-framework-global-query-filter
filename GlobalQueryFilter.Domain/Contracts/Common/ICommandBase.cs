using System.Threading;
using System.Threading.Tasks;

namespace GlobalQueryFilter.Domain.Contracts.Common
{
    public interface ICommandBase<TRequest, TResponse>
    {
        Task<TResponse> ExecuteAsync(TRequest request, CancellationToken cancellationToken);
    }
}
