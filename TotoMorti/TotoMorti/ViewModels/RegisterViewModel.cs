using Prism.Commands;
using Prism.Mvvm;

namespace TotoMorti.ViewModels
{
    public class RegisterViewModel : BindableBase
    {
        public DelegateCommand RegisterCommand { get; private set; }

        public RegisterViewModel()
        {
            RegisterCommand = new DelegateCommand(Register, CanRegister);
        }

        private void Register()
        {
        }

        private bool CanRegister()
        {
            return true;
        }
    }
}
