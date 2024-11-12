using GlobalQueryFilter.Domain.Contracts.Common;
using GlobalQueryFilter.Domain.Dtos;
using static GlobalQueryFilter.Domain.Dtos.GetInvoiceByOwnerQueryDto;

namespace GlobalQueryFilter.Domain.Contracts.Queries
{
    public interface IGetInvoiceByOwnerQuery : IQueryBase<GetInvoiceByOwnerQueryDto, GetInvoicesByOwnerResponseDto>
    {
    }
}
