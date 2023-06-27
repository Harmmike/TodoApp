using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
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

            IServiceProvider serviceProvicer = CreateServiceProvider();

            //TodoAppDbContextFactory dbContextFactory = new TodoAppDbContextFactory(CONNECTION_STRING);
            //ITodoCreator todoCreator = new DatabaseTodoCreator(dbContextFactory);
            //ITodoProvider todoProvider = new DatabaseTodoProvider(dbContextFactory);
            //ITodoIdValidator todoIdValidator = new TodoIdValidator(dbContextFactory);
            //Calendar calendar = new Calendar(todoProvider, todoCreator, todoIdValidator);
            //INavigator nav = new Navigator(calendar);
            //EditViewModel editVM = new EditViewModel();
            //MainWindowViewModel vm = new MainWindowViewModel(nav, calendar, editVM);

            //Start
            //_window = new MainWindow();
            //_window.DataContext = vm;

            MainWindow window = serviceProvicer.GetRequiredService<MainWindow>();
            window.Show();
            //_window.Show();

            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            //Singletons
            services.AddSingleton(new TodoAppDbContextFactory(CONNECTION_STRING));
            services.AddSingleton<ITodoCreator, DatabaseTodoCreator>();
            services.AddSingleton<ITodoProvider, DatabaseTodoProvider>();
            services.AddSingleton<ITodoIdValidator, TodoIdValidator>();
            services.AddSingleton<Calendar>();
            //services.AddSingleton<Calendar>(s => new Calendar(s.GetRequiredService<ITodoProvider>(), s.GetRequiredService<ITodoCreator>(), s.GetRequiredService<ITodoIdValidator>()));

            //Scoped
            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<EditViewModel>();
            services.AddScoped<MainWindowViewModel>();

            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainWindowViewModel>()));

            return services.BuildServiceProvider();
        }

        private DbContextOptions LoadDbOptions()
        {
            return new DbContextOptionsBuilder().UseSqlite(CONNECTION_STRING).Options;
        }
    }
}
