using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using TotoMorti.Classes;

namespace TotoMorti.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            // CelebrityListCommand = new DelegateCommand(NavigateCelebrityList).ObservesCanExecute(p => IsActive);
            CelebrityListCommand = new DelegateCommand(NavigateCelebrityList, CanNavigateCelebrityList);
            SessionsListCommand = new DelegateCommand(NavigateSessionsList, CanNavigateSessionsList);
        }


        public DelegateCommand CelebrityListCommand { get; private set; }

        private bool CanNavigateCelebrityList()
        {
            return true;
        }

        private void NavigateCelebrityList()
        {
            _navigationService.NavigateAsync(PageNames.CelebrityListView);
        }

        public DelegateCommand SessionsListCommand { get; private set; }

        private bool CanNavigateSessionsList()
        {
            return true;
        }

        private void NavigateSessionsList()
        {
            _navigationService.NavigateAsync(PageNames.SessionListView);
        }
    }
}