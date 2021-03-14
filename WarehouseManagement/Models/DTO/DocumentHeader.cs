using System;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Models.DTO
{
    public class DocumentHeader : Price
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public int ClientNumber { get; set; }

        [Required]
        public string ClientName { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
