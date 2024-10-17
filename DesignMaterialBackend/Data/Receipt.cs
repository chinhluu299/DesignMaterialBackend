namespace DesignMaterialBackend.Data
{
    public class Receipt
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string TransactionCode { get; set; }
        public string BankAccountName { get; set; } = "";
        public string BankAccountNumber { get; set; } = "";
        public double Amount { get; set; }
        public string Currency { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool PaymentStatus { get; set; }

        public Guid PaymentAccountId { get; set; }
        public Guid UserId { get; set; }
        public PaymentAccount PaymentAccount { get; set; }
        public User User { get; set; }

    }
}
