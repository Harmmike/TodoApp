using TA.Desktop.State.Navigators;

namespace TA.Desktop.ViewModels
{
    public class MainWIndowViewModel : ViewModel
    {
        public INavigator Navigator { get; set; }
        public EditViewModel EditViewModel { get; set; }

        public MainWIndowViewModel(INavigator navigator, EditViewModel editViewModel)
        {
            Navigator = navigator;
            Navigator.UpdateCurrentView.Execute(ViewType.Home);
            EditViewModel = editViewModel;
        }
    }
}
