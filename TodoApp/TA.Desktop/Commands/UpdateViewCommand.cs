using TA.Desktop.State.Navigators;
using TA.Desktop.ViewModels;

namespace TA.Desktop.Commands
{
    public class UpdateViewCommand : Command
    {
        private readonly INavigator _navigator;

        public UpdateViewCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public override void Execute(object parameter)
        {
            if(parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                switch (viewType)
                {
                    case ViewType.Urgent:
                        break;
                    case ViewType.Completed:
                        break;
                    default:
                        _navigator.CurrentView = new HomeViewModel();
                        break;
                }
            }
        }
    }
}
