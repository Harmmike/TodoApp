using TA.Desktop.State.Navigators;

namespace TA.Desktop.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        public INavigator Navigator { get; set; }
        public EditViewModel EditViewModel { get; set; }

        public MainWindowViewModel(INavigator navigator, EditViewModel editViewModel)
        {
            Navigator = navigator;
            Navigator.UpdateCurrentView.Execute(ViewType.Home);
            EditViewModel = editViewModel;
        }
    }
}
