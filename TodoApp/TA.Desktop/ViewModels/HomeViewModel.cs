using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TA.Domain.Models;

namespace TA.Desktop.ViewModels
{
    public class HomeViewModel : ViewModel
    {
        private readonly ObservableCollection<TodoViewModel> _todos;

        public IEnumerable<TodoViewModel> Todos => _todos;

        public HomeViewModel()
        {
            _todos = new ObservableCollection<TodoViewModel>();

            _todos.Add(new TodoViewModel(new Todo(new Guid(), "Skype Number", "Fix the Auto-Renew on Skype", new System.DateTime(2023, 06, 25, 12, 45, 0), false, false)));
            _todos.Add(new TodoViewModel(new Todo(new Guid(), "Test 2", "Description Text", new System.DateTime(2023, 06, 24, 18, 30, 0), true, false)));
            _todos.Add(new TodoViewModel(new Todo(new Guid(), "Test 3", "Description Text", new System.DateTime(2023, 06, 27, 23, 00, 0), false, false)));
        }
    }
}
