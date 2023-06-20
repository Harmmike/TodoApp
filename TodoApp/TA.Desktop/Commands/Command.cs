using System;
using System.Windows.Input;

namespace TA.Desktop.Commands
{
    public abstract class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public abstract void Execute(object parameter);
    }
}
