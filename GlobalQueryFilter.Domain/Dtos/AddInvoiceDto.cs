namespace GlobalQueryFilter.Domain.Dtos
{
    public readonly struct AddInvoiceCommandDto
    {
        public decimal Value { get; init; }

        public readonly struct AddInvoiceResponseDto
        {
        }
    }
}
