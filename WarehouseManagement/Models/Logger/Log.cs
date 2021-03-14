using System;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Models.Logger
{
    internal class Log
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
