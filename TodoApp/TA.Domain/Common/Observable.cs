using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TA.Domain.Common
{
    public class Observable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }
            storage = value;
            RaisePropertyChanged(propertyName);
            return true;
        }

        protected virtual void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            var handler = PropertyChanged;
            if(handler != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
