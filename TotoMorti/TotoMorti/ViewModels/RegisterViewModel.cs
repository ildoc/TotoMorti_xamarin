using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using TotoMorti.Classes;
using TotoMorti.Interfaces;

namespace TotoMorti.ViewModels
{
    public class RegisterViewModel : BindableBase
    {
        private readonly IAuthentication _authentication;
        private readonly INavigationService _navigationService;

        private string _password;

        private string _username;

        public RegisterViewModel(INavigationService navigationService, IAuthentication authentication)
        {
            _navigationService = navigationService;
            _authentication = authentication;
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
            _authentication.SaveCredentials(Username, Password);
            _navigationService.NavigateAsync(PageNames.MainView);
        }

        private bool CanRegister()
        {
            return true;
        }
    }
}