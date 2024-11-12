using System.Collections.Generic;

namespace GlobalQueryFilter.Domain.Dtos
{
    public record GetInvoiceByOwnerQueryDto
    {
        public readonly struct GetInvoicesByOwnerResponseDto
        {
            public IEnumerable<GetInvoiceByOwnerResponseDto> Invoices { get; init; }
        }

        public readonly struct GetInvoiceByOwnerResponseDto
        {
            public string Owner { get; init; }
            public decimal Value { get; init; }
        }
    }
}
