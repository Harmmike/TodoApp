using System.Threading.Tasks;

namespace TA.Desktop.Commands
{
    public abstract class AsyncCommand : Command
    {
        private bool _isExecuting { get; set; }
        private bool IsExecuting
        {
            get => _isExecuting;
            set
            {
                _isExecuting = value;
                OnCanExecuteChanged();
            }
        }
        
        public override bool CanExecute(object parameter)
        {
            return !IsExecuting && base.CanExecute(parameter);
        }

        public override async void Execute(object parameter)
        {
            _isExecuting = true;
            try
            {
                await ExecuteAsync(parameter);
            }
            finally
            {
                _isExecuting = false;
            }
        }

        public abstract Task ExecuteAsync(object parameter);
    }
}
