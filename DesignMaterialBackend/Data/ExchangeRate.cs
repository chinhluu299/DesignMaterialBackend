

namespace DesignMaterialBackend.Data
{
    public class ExchangeRate
    {
        public Guid Id { get; set; }
        public float Rate { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; }
        public bool Active { get; set; } = false;
      
        public CurrencyUnit CurrencyUnit { get; set; }

    }
}
