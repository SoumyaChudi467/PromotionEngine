using System.ComponentModel.DataAnnotations;

namespace PromotionEngine.Contracts
{
    public class Product
    {
        [Required]
        public string SkuId { get; set; }
        [Required]
        public int ProductCount { get; set; }
    }
}