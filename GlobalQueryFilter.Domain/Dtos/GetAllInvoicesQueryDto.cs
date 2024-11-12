using System.Collections.Generic;

namespace GlobalQueryFilter.Domain.Dtos
{
    public record GetAllInvoicesQueryDto
    {
        public readonly struct GetAllInvoicesResponseDto
        {
            public IEnumerable<GetAllInvoiceResponseDto> Invoices { get; init; }
        }

        public readonly struct GetAllInvoiceResponseDto
        {
            public string Owner { get; init; }
            public decimal Value { get; init; }
        }
    }
}
