using System.Windows.Input;
using TA.Desktop.Commands;
using TA.Desktop.ViewModels;
using TA.Domain.Common;
using TA.Domain.Models;

namespace TA.Desktop.State.Navigators
{
    public class Navigator : Observable, INavigator
    {
        private readonly Calendar _calendar;

        private Todo _selectedTodo;

        public ViewModel CurrentView { get; set; }
        public Todo SelectedTodo
        {
            get => _selectedTodo;
            set => SetProperty(ref _selectedTodo, value);
        }

        public ICommand UpdateCurrentView { get; set; }

        public Navigator(Calendar calendar)
        {
            _calendar = calendar;
            UpdateCurrentView = new UpdateViewCommand(this, _calendar);
        }
    }
}
