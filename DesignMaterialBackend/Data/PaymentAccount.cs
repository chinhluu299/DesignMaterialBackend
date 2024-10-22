namespace DesignMaterialBackend.Data
{
    public class PaymentAccount
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? AccountNumber { get; set; }
        public string? BankName { get; set; }
        public string? MomoNumber { get; set; }
        public string? ZaloNumber { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Guid PaymentTypeId { get; set; }
        public PaymentType? PaymentType { get; set; }

        public List<Receipt>  ReceiptList { get; set; }

    }
}
