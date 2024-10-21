namespace TSDashBoardApi.Core.Domain
{
    public class Payments
    {
        public  int Id { get; set; }
        public int? InvoiceId { get; set; }
        public required DateOnly PaymentDate { get; set; }
        public required Decimal Amount { get; set; }
        public required string Method { get; set; }

    }
}
