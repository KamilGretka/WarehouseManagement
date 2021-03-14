using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WarehouseManagement.Commands;
using WarehouseManagement.Logic;
using WarehouseManagement.Models.DTO;

namespace WarehouseManagement.ViewModels
{
    public class ProductViewModel
    {
        public Command Confirm { get; set; }

        public string ProductName { get; set; }

        public int Amount { get; set; }

        public decimal NetPrice { get; set; }

        internal DataGrid products;

        public ProductViewModel(DataGrid dataGridProducts)
        {
            Confirm = new Command(ConfirmProduct);
            products = dataGridProducts;
        }

        public void ConfirmProduct()
        {
            Product product = new Product()
            {
                Amount = Amount,
                NetPrice = NetPrice * Amount,
                Name = ProductName,
                GrossPrice = NetPrice * Amount * (decimal)1.23
            };

            List<(string, bool)> validators = DataValidation.CheckProductFields(product);

            foreach (var validator in validators)
            {
                if (!validator.Item2)
                {
                    MessageBox.Show(validator.Item1, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
                }
            }

            if (validators.TrueForAll(x => x.Item2))
            {
                products.Items.Add(product);
            }
        }
    }
}