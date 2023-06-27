using TA.Desktop.State.Navigators;
using TA.Desktop.ViewModels;
using TA.Domain.Models;

namespace TA.Desktop.Commands
{
    public class UpdateViewCommand : Command
    {
        private readonly INavigator _navigator;
        private readonly Calendar _calendar;

        public UpdateViewCommand(INavigator navigator, Calendar calendar)
        {
            _navigator = navigator;
            _calendar = calendar;
        }

        public override void Execute(object parameter)
        {
            if(parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                switch (viewType)
                {
                    case ViewType.Add:
                        break;
                    case ViewType.Urgent:
                        break;
                    case ViewType.Completed:
                        break;
                    default:
                        _navigator.CurrentView = HomeViewModel.LoadViewModel(_calendar);
                        break;
                }
            }
        }
    }
}
