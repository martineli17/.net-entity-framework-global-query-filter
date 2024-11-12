using GlobalQueryFilter.Domain.Contracts.Common;
using GlobalQueryFilter.Domain.Dtos;

namespace GlobalQueryFilter.Domain.Contracts.Commands
{
    public interface IAddInvoiceCommand : ICommandBase<AddInvoiceCommandDto, AddInvoiceCommandDto.AddInvoiceResponseDto>
    {
        
    }
}
