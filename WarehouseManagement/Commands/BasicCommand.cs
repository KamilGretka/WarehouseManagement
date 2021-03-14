using System;
using System.Windows.Input;

namespace WarehouseManagement.Commands
{
    public class BasicCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        protected Action _execute;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute.Invoke();
        }
    }
}