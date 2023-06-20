using TA.Desktop.State.Navigators;
using TA.Domain.Models;

namespace TA.Desktop.ViewModels
{
    public class EditViewModel : ViewModel
    {
        private Todo _selectedTodo;

        public Todo SelectedTodo
        {
            get => _selectedTodo;
            set => SetProperty(ref _selectedTodo, value);
        }
    }
}
