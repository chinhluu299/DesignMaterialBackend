using Microsoft.AspNetCore.Identity;

namespace DesignMaterialBackend.Data
{
    public class User : IdentityUser<Guid>
    {
        public double Coins { get; set; }
        public List<Receipt> Receipts { get; set; }
    }
}
