using System.ComponentModel;
using System.Runtime.CompilerServices;
using TotoMorti.Annotations;

namespace TotoMorti.Classes.Abstracts
{
    public class PropertyChangeAware : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}