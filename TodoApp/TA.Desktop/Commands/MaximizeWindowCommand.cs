using System;
using System.Windows;

namespace TA.Desktop.Commands
{
    public class MaximizeWindowCommand : Command
    {
        public override void Execute(object parameter)
        {
            if(parameter is Window)
            {
                Window window = (Window)parameter;
                window.WindowState = WindowState.Maximized;
            }
        }
    }
}
