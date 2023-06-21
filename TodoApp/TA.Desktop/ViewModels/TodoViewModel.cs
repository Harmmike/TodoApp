using System;
using TA.Domain.Models;

namespace TA.Desktop.ViewModels
{
    public class TodoViewModel : ViewModel
    {
        private readonly Todo _todo;

        private bool _isSelected;

        public string TodoId => _todo.Id.Id;
        public string Title => _todo.Title;
        public string DueDate => _todo.Due.ToShortDateString();
        public string DueTime => _todo.Due.ToShortTimeString();
        public bool IsUrgent => _todo.IsUrgent;
        public bool IsComplete => _todo.IsComplete;

        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }


        public TodoViewModel(Todo todo)
        {
            _todo = todo;
        }
    }
}
