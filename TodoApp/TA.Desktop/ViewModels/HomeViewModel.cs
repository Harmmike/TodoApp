using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TA.Desktop.Commands;
using TA.Domain.Models;

namespace TA.Desktop.ViewModels
{
    public class HomeViewModel : ViewModel
    {
        private readonly Calendar _calendar;

        private readonly ObservableCollection<TodoViewModel> _todos;

        public IEnumerable<TodoViewModel> Todos => _todos;

        public ICommand LoadTodos { get; set; }

        public HomeViewModel(Calendar calendar)
        {
            _calendar = calendar;
            _todos = new ObservableCollection<TodoViewModel>();

            LoadTodos = new LoadTodosCommand(_calendar, this);
        }

        public void UpdateTodos(IEnumerable<Todo> todos)
        {
            _todos.Clear();
            foreach (var todo in todos)
            {
                TodoViewModel todoViewModel = new TodoViewModel(todo);
                _todos.Add(todoViewModel);
            }
        }

        public static HomeViewModel LoadViewModel(Calendar calendar)
        {
            HomeViewModel viewModel = new HomeViewModel(calendar);
            viewModel.LoadTodos.Execute(null);
            return viewModel;
        }
    }
}
