using System.Windows;
using WarehouseManagement.ViewModels;

namespace WarehouseManagement.Views
{
    public partial class DocumentWindow : Window
    {
        public DocumentWindow()
        {
            InitializeComponent();
            DataContext = new DocumentViewModel(ProductsDataGrid);
        }
    }
}