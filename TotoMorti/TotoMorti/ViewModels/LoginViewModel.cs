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

        public LoginViewModel(INavigationService navigationService, IAuthentication authentication)
        {
            _navigationService = navigationService;
            _authentication = authentication;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (_authentication.DoCredentialsExist())
                _navigationService.NavigateAsync(PageNames.MainView);
        }
    }
}
