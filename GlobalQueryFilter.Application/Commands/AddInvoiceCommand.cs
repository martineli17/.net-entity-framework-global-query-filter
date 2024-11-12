using GlobalQueryFilter.Domain.Contracts.Commands;
using GlobalQueryFilter.Domain.Contracts.Common;
using GlobalQueryFilter.Domain.Contracts.Repositories;
using GlobalQueryFilter.Domain.Dtos;
using GlobalQueryFilter.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace GlobalQueryFilter.Application.Commands
{
    public class AddInvoiceCommand : IAddInvoiceCommand
    {
        private readonly IUserRequest _userRequest;
        private readonly IInvoiceRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public AddInvoiceCommand(IUserRequest userRequest, IInvoiceRepository repository, IUnitOfWork unitOfWork)
        {
            _userRequest = userRequest;
            _repository = repository;
            _unitOfWork= unitOfWork;
        }

        public async Task<AddInvoiceCommandDto.AddInvoiceResponseDto> ExecuteAsync(AddInvoiceCommandDto request, CancellationToken cancellationToken)
        {
            var invoice = new Invoice(_userRequest.Email, request.Value);

            await _repository.AddAsync(invoice, cancellationToken).ConfigureAwait(false);
            await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false);

            return new();
        }
    }
}
