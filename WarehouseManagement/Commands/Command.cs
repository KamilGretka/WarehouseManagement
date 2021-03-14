using System;

namespace WarehouseManagement.Commands
{
    public class Command : BasicCommand
    {
        public Command(Action Execute)
        {
            _execute = Execute;
        }
    }
}