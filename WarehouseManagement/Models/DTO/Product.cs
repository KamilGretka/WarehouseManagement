using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagement.Models.DTO
{
    public class Product : Price
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public Guid DocumentId { get; set; }

        [ForeignKey("DocumentId")]
        public DocumentHeader DocumentFK { get; set; }
    }
}