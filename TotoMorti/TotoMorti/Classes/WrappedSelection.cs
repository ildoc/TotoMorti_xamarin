using System.ComponentModel;

namespace TotoMorti.Classes
{
    public class WrappedSelection<T> : INotifyPropertyChanged
    {
        private bool isSelected;
        public T Item { get; set; }

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("IsSelected"));
                    //						PropertyChanged (this, new PropertyChangedEventArgs (nameof (IsSelected))); // C# 6
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}