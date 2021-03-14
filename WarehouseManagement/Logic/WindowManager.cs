using WarehouseManagement.Views;

namespace WarehouseManagement.Logic
{
    public class WindowsManager
    {
        public static DocumentWindow documentWindow;
        public static WarehouseWindow warehouseWindow;
        public static ProductWindow productWindow;

        public static DocumentWindow GetDocumentWindowInstance()
        {
            if (documentWindow == null || !documentWindow.IsEnabled)
            {
                documentWindow = new DocumentWindow();
            }
            return documentWindow;
        }

        public static WarehouseWindow GetWarehouseWindowInstance()
        {
            if (warehouseWindow == null || !warehouseWindow.IsEnabled)
            {
                warehouseWindow = new WarehouseWindow();
            }
            return warehouseWindow;
        }

        public static ProductWindow GetProductWindowInstance(System.Windows.Controls.DataGrid productsDataGrid = null)
        {
            if (productWindow == null)
            {
                productWindow = new ProductWindow(productsDataGrid);
            }
            return productWindow;
        }
    }
}