namespace DesignMaterialBackend.Data
{
    public class PaymentType
    { 
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsOnline { get; set; } = true;
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; }
    }
}
