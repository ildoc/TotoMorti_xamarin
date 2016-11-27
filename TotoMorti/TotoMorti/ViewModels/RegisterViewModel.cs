using Prism.Commands;
using Prism.Mvvm;

namespace TotoMorti.ViewModels
{
    public class RegisterViewModel : BindableBase
    {
        public RegisterViewModel()
        {
            RegisterCommand = new DelegateCommand(Register, CanRegister);
        }

        public DelegateCommand RegisterCommand { get; private set; }

        private void Register()
        {
        }

        private bool CanRegister()
        {
            return true;
        }
    }
}