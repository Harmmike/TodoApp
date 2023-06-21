using System.Windows;

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
        }
    }
}
