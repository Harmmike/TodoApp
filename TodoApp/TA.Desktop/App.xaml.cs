using Microsoft.EntityFrameworkCore;
using System.Windows;
using TA.Desktop.State.Navigators;
using TA.Desktop.ViewModels;
using TA.Desktop.Windows;
using TA.Domain.Models;
using TA.Domain.Services.DbContexts;
using TA.Domain.Services.Providers;
using TA.Domain.Services.TodoCreators;
using TA.Domain.Services.Validation;

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
            using (TodoAppDbContext dbContext = new TodoAppDbContext(options))
            {
                dbContext.Database.Migrate();
            }
            TodoAppDbContextFactory dbContextFactory = new TodoAppDbContextFactory(CONNECTION_STRING);
            ITodoCreator todoCreator = new DatabaseTodoCreator(dbContextFactory);
            ITodoProvider todoProvider = new DatabaseTodoProvider(dbContextFactory);
            ITodoIdValidator todoIdValidator = new TodoIdValidator(dbContextFactory);
            Calendar calendar = new Calendar(todoProvider, todoCreator, todoIdValidator);
            INavigator nav = new Navigator(calendar);
            EditViewModel editVM = new EditViewModel();
            MainWindowViewModel vm = new MainWindowViewModel(nav, calendar, editVM);

            //Start
            _window = new MainWindow();
            _window.DataContext = vm;
            _window.Show();

            base.OnStartup(e);
        }

        private void CreateServiceProvider()
        {

        }
    }
}
