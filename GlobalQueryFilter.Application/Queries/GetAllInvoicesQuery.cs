using GlobalQueryFilter.Domain.Contracts.Common;
using GlobalQueryFilter.Domain.Contracts.Queries;
using GlobalQueryFilter.Domain.Contracts.Repositories;
using GlobalQueryFilter.Domain.Dtos;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static GlobalQueryFilter.Domain.Dtos.GetAllInvoicesQueryDto;

namespace GlobalQueryFilter.Application.Queries
{
    public class GetAllInvoicesQuery : IGetAllInvoicesQuery
    {
        private readonly IUserRequest _userRequest;
        private readonly IInvoiceRepository _repository;

        public GetAllInvoicesQuery(IUserRequest userRequest, IInvoiceRepository repository)
        {
            _userRequest = userRequest;
            _repository = repository;
        }

        public async Task<GetAllInvoicesResponseDto> ExecuteAsync(GetAllInvoicesQueryDto request, CancellationToken cancellationToken)
        {
            var invoices = await _repository.GetAllAsync(cancellationToken).ConfigureAwait(false);
            return new()
            {
                Invoices = invoices.Select(x => new GetAllInvoiceResponseDto()
                {
                    Owner = x.Owner,
                    Value = x.Value,
                })
            };
        }
    }
}
