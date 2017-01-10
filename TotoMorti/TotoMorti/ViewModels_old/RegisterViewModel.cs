using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using TotoMorti.Classes;

namespace TotoMorti.ViewModels
{
    public class RegisterViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;

        private string _password;

        private string _username;

        public RegisterViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            RegisterCommand = new DelegateCommand(Register, CanRegister);
        }

        public DelegateCommand RegisterCommand { get; private set; }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        private void Register()
        {
            // _authentication.SaveCredentials(Username, Password);
            _navigationService.NavigateAsync(PageNames.MainView);
        }

        private bool CanRegister()
        {
            return true;
        }
    }
}