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

            //_todos.Add(new TodoViewModel(new Todo(new Guid(), "Skype Number", "Fix the Auto-Renew on Skype", DateTime.Now, new System.DateTime(2023, 06, 25, 12, 45, 0), false, false)));
            //_todos.Add(new TodoViewModel(new Todo(new Guid(), "Test 2", "Description Text", DateTime.Now, new System.DateTime(2023, 06, 24, 18, 30, 0), true, false)));
            //_todos.Add(new TodoViewModel(new Todo(new Guid(), "Test 3", "Description Text", DateTime.Now.AddDays(-2), new System.DateTime(2023, 06, 27, 23, 00, 0), false, false)));
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
