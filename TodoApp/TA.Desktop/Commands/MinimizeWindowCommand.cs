using System.Windows;
using TA.Domain.Exceptions;

namespace TA.Desktop.Commands
{
    public class MinimizeWindowCommand : Command
    {
        public override void Execute(object parameter)
        {
            if(parameter is Window)
            {
                Window window = parameter as Window;
                switch (window.WindowState)
                {
                    case WindowState.Normal:
                        window.WindowState = WindowState.Minimized;
                        break;
                    case WindowState.Maximized:
                        window.WindowState = WindowState.Normal;
                        break;
                }
            }
            else
            {
                throw new InvalidArgumentException("Parameter is not of type Window.");
            }
        }
    }
}
