using GlobalQueryFilter.Domain.Contracts.Common;
using GlobalQueryFilter.Domain.Contracts.Queries;
using GlobalQueryFilter.Domain.Contracts.Repositories;
using GlobalQueryFilter.Domain.Dtos;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static GlobalQueryFilter.Domain.Dtos.GetInvoiceByOwnerQueryDto;

namespace GlobalQueryFilter.Application.Queries
{
    public class GetInvoiceByOwnerQuery : IGetInvoiceByOwnerQuery
    {
        private readonly IUserRequest _userRequest;
        private readonly IInvoiceRepository _repository;

        public GetInvoiceByOwnerQuery(IUserRequest userRequest, IInvoiceRepository repository)
        {
            _userRequest = userRequest;
            _repository = repository;
        }

        public async Task<GetInvoicesByOwnerResponseDto> ExecuteAsync(GetInvoiceByOwnerQueryDto _, CancellationToken cancellationToken)
        {
            var invoices = await _repository.GetByOwnerAsync(_userRequest.Email, cancellationToken).ConfigureAwait(false);
            return new()
            {
                Invoices = invoices.Select(x => new GetInvoiceByOwnerResponseDto()
                {
                    Owner = x.Owner,
                    Value = x.Value,
                })
            };
        }
    }
}
