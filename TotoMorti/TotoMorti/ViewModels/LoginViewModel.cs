using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using TotoMorti.Classes;
using TotoMorti.Interfaces;

namespace TotoMorti.ViewModels
{
    public class LoginViewModel : BindableBase, INavigationAware
    {
        private INavigationService _navigationService;
        private IAuthentication _authentication;

        public DelegateCommand LoginCommand { get; private set; }
        public DelegateCommand NavigateRegisterCommand { get; private set; }

        public LoginViewModel(INavigationService navigationService)//, IAuthentication authentication)
        {
            _navigationService = navigationService;
            //_authentication = authentication;
            LoginCommand = new DelegateCommand(Login, CanLogin);
            NavigateRegisterCommand = new DelegateCommand(NavigateRegister, CanNavigateRegister);
        }

        private void NavigateRegister()
        {
            _navigationService.NavigateAsync(PageNames.RegisterView);
        }

        private bool CanNavigateRegister()
        {
            return true;
        }

        private bool CanLogin()
        {
            return true;
        }

        private void Login()
        {
            _navigationService.NavigateAsync(PageNames.MainView);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            //if (_authentication.DoCredentialsExist())
            //    _navigationService.NavigateAsync(PageNames.MainView);
        }
    }
}
