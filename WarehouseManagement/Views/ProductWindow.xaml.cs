using System.Windows;
using System.Windows.Controls;
using WarehouseManagement.ViewModels;

namespace WarehouseManagement.Views
{
    public partial class ProductWindow : Window
    {
        public ProductWindow(DataGrid productsDataGrid)
        {
            InitializeComponent();
            DataContext = new ProductViewModel(productsDataGrid);
        }
    }
}