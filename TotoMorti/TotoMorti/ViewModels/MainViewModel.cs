using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using TotoMorti.Classes;

namespace TotoMorti.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private bool _isActive;
        private readonly INavigationService _navigationService;
        private string _title = "MainPage";

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            CelebrityListCommand = new DelegateCommand(NavigateCelebrityList).ObservesCanExecute(p => IsActive);
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public bool IsActive
        {
            get { return _isActive; }
            set { SetProperty(ref _isActive, value); }
        }

        public DelegateCommand CelebrityListCommand { get; private set; }

        private void NavigateCelebrityList()
        {
            _navigationService.NavigateAsync(PageNames.CelebrityListView);
        }

        private bool CanNavigate()
        {
            return IsActive;
        }

        //}
        //        Title = (string)parameters["title"] + " and Prism";
        //    if (parameters.ContainsKey("title"))
        //{

        //public void OnNavigatedTo(NavigationParameters parameters)
        //}
        //{

        //public void OnNavigatedFrom(NavigationParameters parameters)
    }
}