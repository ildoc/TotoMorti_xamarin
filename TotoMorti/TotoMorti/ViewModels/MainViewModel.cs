using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using TotoMorti.Classes;

namespace TotoMorti.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private INavigationService _navigationService;
        private string _title = "MainPage";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            CelebrityListCommand = new DelegateCommand(NavigateCelebrityList).ObservesCanExecute((p) => IsActive);
        }

        private void NavigateCelebrityList()
        {
            _navigationService.NavigateAsync(PageNames.CelebrityListView);
        }

        private bool CanNavigate()
        {
            return IsActive;
        }

        private bool _isActive = false;

        public bool IsActive
        {
            get { return _isActive; }
            set { SetProperty(ref _isActive, value); }
        }

        public DelegateCommand CelebrityListCommand { get; private set; }

        //public void OnNavigatedFrom(NavigationParameters parameters)
        //{
        //}

        //public void OnNavigatedTo(NavigationParameters parameters)
        //{
        //    if (parameters.ContainsKey("title"))
        //        Title = (string)parameters["title"] + " and Prism";
        //}
    }
}
