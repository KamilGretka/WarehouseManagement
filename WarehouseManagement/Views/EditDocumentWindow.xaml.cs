using System.Windows;
using WarehouseManagement.Database;
using WarehouseManagement.Models.DTO;
using WarehouseManagement.ViewModels;

namespace WarehouseManagement.Views
{
    public partial class EditDocumentWindow : Window
    {
        public EditDocumentWindow(DocumentHeader selectedHeader)
        {
            InitializeComponent();
            ClientNameTextBox.Text = selectedHeader.ClientName;
            DateTextBox.Text = selectedHeader.Date.ToString();
            NetPriceTextBox.Text = selectedHeader.NetPrice.ToString();

            DataContext = new EditDocumentViewModel(null);

            ProductsItems.ItemsSource = DocumentDatabaseHelper.GetProductsByDocumentId(selectedHeader.ID);
        }
    }
}