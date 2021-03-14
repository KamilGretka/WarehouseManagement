using System;
using System.IO;

namespace WarehouseManagement.Config
{
    internal class DatabaseConfiguration
    {
        internal static string ConnectionString = string.Format(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={0}\WarehouseManagement\Database\WarehouseDB.mdf;Integrated Security=True",
                                                    Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName);
    }
}