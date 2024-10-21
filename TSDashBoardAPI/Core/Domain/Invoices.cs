﻿namespace TSDashBoardApi.Core.Domain
{
    public class Invoices
    {
        public  int Id { get; set; }
        public int? CustomerId { get; set; }
        public required DateOnly Date { get; set; }
        public required DateOnly DueDate { get; set; }
        public required Decimal TotalAmount { get; set; }
        public required string Status { get; set; }
    }
}