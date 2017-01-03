using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using TotoMorti.Classes;
using TotoMorti.Resx;

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
            GroupsCommand = new DelegateCommand(NavigateGroups, CanNavigateGroups);
            TotoListFormCommand = new DelegateCommand(NavigateTotoListForm, CanNavigateTotoListForm);
        }

        public string AppTitle => $"{AppResources.AppName}";

        public DelegateCommand CelebrityListCommand { get; private set; }

        public DelegateCommand GroupsCommand { get; private set; }

        public DelegateCommand TotoListFormCommand { get; private set; }

        private bool CanNavigateCelebrityList()
        {
            return false;
        }

        private void NavigateCelebrityList()
        {
            _navigationService.NavigateAsync(PageNames.CelebrityListView);
        }

        private bool CanNavigateGroups()
        {
            return false;
        }

        private void NavigateGroups()
        {
            _navigationService.NavigateAsync(PageNames.SessionListView);
        }

        private bool CanNavigateTotoListForm()
        {
            return true;
        }

        private void NavigateTotoListForm()
        {
            _navigationService.NavigateAsync(PageNames.CategoryListFormView);
        }
    }
}