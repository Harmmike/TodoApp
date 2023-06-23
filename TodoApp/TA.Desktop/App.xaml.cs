using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Markup;
using TA.Desktop.State.Navigators;
using TA.Desktop.ViewModels;
using TA.Desktop.Windows;
using TA.Domain.Services.DbContexts;

namespace TA.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string CONNECTION_STRING = "Data Source=todoapp.db";

        private MainWindow _window;

        /// <summary>
        /// Application entry-point.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            //Dependencies
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(CONNECTION_STRING).Options;
            TodoAppDbContext dbContext = new TodoAppDbContext(options);
            dbContext.Database.Migrate();

            INavigator nav = new Navigator();
            EditViewModel editVM = new EditViewModel();
            MainWindowViewModel vm = new MainWindowViewModel(nav, editVM);

            //Start
            _window = new MainWindow();
            _window.DataContext = vm;
            _window.Show();

            base.OnStartup(e);
        }
    }
}
