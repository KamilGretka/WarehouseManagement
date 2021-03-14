using System.Windows;
using WarehouseManagement.ViewModels;

namespace WarehouseManagement.Views
{
    public partial class WarehouseWindow : Window
    {
        public WarehouseWindow()
        {
            InitializeComponent();
            DataContext = new WarehouseViewModel(ProductsItemsGrid);
        }
    }
}