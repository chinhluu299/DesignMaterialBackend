namespace DesignMaterialBackend.Data
{
    public class CurrencyUnit
    {
        public Guid Id { get; set; }
        public string Unit { get; set; }
        public string Description { get; set; } 
        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}
