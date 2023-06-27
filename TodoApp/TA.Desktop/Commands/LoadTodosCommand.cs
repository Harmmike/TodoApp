using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Desktop.ViewModels;
using TA.Domain.Models;

namespace TA.Desktop.Commands
{
    public class LoadTodosCommand : AsyncCommand
    {
        private readonly Calendar _calendar;
        private readonly HomeViewModel _homeViewModel;

        public LoadTodosCommand(Calendar calendar, HomeViewModel homeViewModel)
        {
            _calendar = calendar;
            _homeViewModel = homeViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                IEnumerable<Todo> todos = await _calendar.GetAllTodosAsync();
                _homeViewModel.UpdateTodos(todos);
            }
            catch (Exception)
            {

                throw new Exception("Unable to load Todos from ExecuteAsync in LoadTodosCommand.cs");
            }
        }
    }
}
