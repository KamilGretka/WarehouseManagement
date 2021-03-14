using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WarehouseManagement.Commands;
using WarehouseManagement.Database;
using WarehouseManagement.Messages;
using WarehouseManagement.Views;

namespace WarehouseManagement.ViewModels
{
    public class DocumentViewModel
    {
        public Command AddCommand { get; set; }

        public Command ConfirmCommand { get; set; }

        public string ClientNameViewInput { get; set; }

        public int ClientNumberViewInput { get; set; }

        public DateTime Date { get; set; }

        internal DataGrid ProductsDataGrid { get; set; }


        public DocumentViewModel(DataGrid productsDataGrid)
        {
            AddCommand = new Command(AddProduct);
            ConfirmCommand = new Command(ConfirmProduct);
            ProductsDataGrid = productsDataGrid;
        }

        public void AddProduct()
        {
            if (!string.IsNullOrWhiteSpace(ClientNameViewInput) && !ClientNameViewInput.All(char.IsDigit))
            {
                ProductWindow productWindow = new ProductWindow(ProductsDataGrid);
                productWindow.Show();
            }
            else
            {
                MessageBox.Show(UserMessages.ClientNameIsEmptyOrInvalidFormat, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        public void ConfirmProduct()
        {
            DocumentDatabaseHelper.AddDocuments(this);
            MessageBox.Show($"Document successfully added to database", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}