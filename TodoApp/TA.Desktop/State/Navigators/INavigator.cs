using System.Windows.Input;
using TA.Desktop.ViewModels;
using TA.Domain.Models;

namespace TA.Desktop.State.Navigators
{
    public interface INavigator
    {
        ViewModel CurrentView { get; set; }
        Todo SelectedTodo { get; set; }
        ICommand UpdateCurrentView { get; }
    }

    public enum ViewType
    {
        Home, Urgent, Completed
    }
}
