using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Models.DTO
{
    public class Price
    {
        [Required]
        public decimal GrossPrice { get; set; }

        [Required]
        public decimal NetPrice { get; set; }
    }
}