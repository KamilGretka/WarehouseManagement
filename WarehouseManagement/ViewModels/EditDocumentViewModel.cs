using System;
using System.Windows;
using WarehouseManagement.Commands;
using WarehouseManagement.Models.DTO;

namespace WarehouseManagement.ViewModels
{
    public class EditDocumentViewModel
    {
        public int ClientName { get; set; }

        public DateTime Date { get; set; }

        public decimal NetPrice { get; set; }

        public Command Confirm { get; set; }

        private DocumentHeader _selectedHeader;

        public EditDocumentViewModel(DocumentHeader selectedHeader)
        {
            Confirm = new Command(ConfirmButton);
            _selectedHeader = selectedHeader;           
            
        }

        public void ConfirmButton()
        {
            try
            {
                throw new NotImplementedException();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
