using System.Windows;
using TA.Desktop.State.Navigators;
using TA.Desktop.ViewModels;
using TA.Desktop.Windows;

namespace TA.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainWindow _window;

        /// <summary>
        /// Application entry-point.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            //Dependencies
            INavigator nav = new Navigator();
            EditViewModel editVM = new EditViewModel();
            MainWIndowViewModel vm = new MainWIndowViewModel(nav, editVM);

            //Start
            _window = new MainWindow();
            _window.DataContext = vm;
            _window.Show();

            base.OnStartup(e);
        }
    }
}
