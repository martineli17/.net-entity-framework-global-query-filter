using GlobalQueryFilter.Domain.Contracts.Common;
using GlobalQueryFilter.Domain.Dtos;
using static GlobalQueryFilter.Domain.Dtos.GetAllInvoicesQueryDto;

namespace GlobalQueryFilter.Domain.Contracts.Queries
{
    public interface IGetAllInvoicesQuery : IQueryBase<GetAllInvoicesQueryDto, GetAllInvoicesResponseDto>
    {

    }
}
