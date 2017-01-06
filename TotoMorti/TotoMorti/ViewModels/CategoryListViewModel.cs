using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using TotoMorti.Classes;
using TotoMorti.Models;

namespace TotoMorti.ViewModels
{
    public class CategoryListViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private TotoList _currentTotoList;

        public CategoryListViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            AddCommand = new DelegateCommand(AddCategory);
        }

        public TotoList CurrentTotoList
        {
            get { return _currentTotoList; }
            set { SetProperty(ref _currentTotoList, value); }
        }

        public DelegateCommand AddCommand { get; set; }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("totoList"))
                CurrentTotoList = (TotoList) parameters["totoList"];
        }

        private void AddCategory()
        {
            var p = new NavigationParameters
            {
                {"action", FormStatus.Add},
                {"listGuid", CurrentTotoList.ListGuid}
            };

            _navigationService.NavigateAsync(PageNames.CategoryFormView, p);
        }
    }
}