using System.Data.Entity;
using WarehouseManagement.Config;
using WarehouseManagement.Models.DTO;
using WarehouseManagement.Models.Logger;

namespace WarehouseManagement.Models.Database
{
    internal class AppDBContext : DbContext
    {
        public AppDBContext() : base(DatabaseConfiguration.ConnectionString)
        {

        }

        public DbSet<DocumentHeader> DocumentHeader { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Log> Logs { get; set; }
    }
}