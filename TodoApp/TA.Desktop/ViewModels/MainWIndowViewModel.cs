using System.Windows.Input;
using TA.Desktop.Commands;
using TA.Desktop.State.Navigators;

namespace TA.Desktop.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        public INavigator Navigator { get; set; }
        public EditViewModel EditViewModel { get; set; }

        public ICommand MinimizeWindow { get; set; }
        public ICommand MaximizeWindow { get; set; }
        public ICommand CloseApplication { get; set; }
        public MainWindowViewModel(INavigator navigator, EditViewModel editViewModel)
        {
            MinimizeWindow = new MinimizeWindowCommand();
            MaximizeWindow = new MaximizeWindowCommand();
            CloseApplication = new CloseApplicationCommand();

            Navigator = navigator;
            Navigator.UpdateCurrentView.Execute(ViewType.Home);
            EditViewModel = editViewModel;
        }
    }
}
