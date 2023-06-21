using TA.Domain.Models;

namespace TA.Desktop.ViewModels
{
    public class HomeViewModel : ViewModel
    {
        private Todo _selectedTodo;

        public Todo SelectedTodo
        {
            get => _selectedTodo;
            set
            {
                if(SelectedTodo != null)
                {
                    SelectedTodo.IsSelected = false;
                }
                SetProperty(ref _selectedTodo, value);
                SelectedTodo.IsSelected = true;
            }
        }
    }
}
