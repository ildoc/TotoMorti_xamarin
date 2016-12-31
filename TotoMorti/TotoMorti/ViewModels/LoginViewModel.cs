using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using TotoMorti.Classes;

namespace TotoMorti.ViewModels
{
    public class LoginViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;

        public LoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            LoginCommand = new DelegateCommand(Login, CanLogin);
            NavigateRegisterCommand = new DelegateCommand(NavigateRegister, CanNavigateRegister);
        }

        public DelegateCommand LoginCommand { get; private set; }
        public DelegateCommand NavigateRegisterCommand { get; private set; }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            // if (_authentication.DoCredentialsExist())
            //    _navigationService.NavigateAsync(PageNames.MainView);
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
    }
}