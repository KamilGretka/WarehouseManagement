using DevExpress.Xpf.Grid;
using WarehouseManagement.Commands;
using WarehouseManagement.Database;
using WarehouseManagement.Models.DTO;
using WarehouseManagement.Views;

namespace WarehouseManagement.ViewModels
{
    public class WarehouseViewModel
    {
        public Command Add { get; set; }
        public Command Edit { get; set; }
        public Command Remove { get; set; }

        internal GridControl productsItemsGrid;

        public WarehouseViewModel(GridControl productsGrid)
        {
            Add = new Command(ChangeToDocumentView);
            Edit = new Command(EditHeader);
            Remove = new Command(RemoveHeader);
            productsItemsGrid = productsGrid;
        }

        public void ChangeToDocumentView()
        {
            DocumentWindow document = new DocumentWindow();
            document.Show();
        }

        public void EditHeader()
        {
            DocumentHeader selectedHeader = (DocumentHeader)productsItemsGrid.SelectedItem;

            if (selectedHeader is null)
                return;

            var editProductWindow = new EditDocumentWindow(selectedHeader);
            editProductWindow.Show();
            editProductWindow.Focus();
        }

        public void RemoveHeader()
        {
            DocumentHeader selectedHeader = (DocumentHeader)productsItemsGrid.SelectedItem;

            if (selectedHeader is null)
                return;
            DocumentDatabaseHelper.RemoveDocumentById(selectedHeader.ID);
            
        }
    }
}