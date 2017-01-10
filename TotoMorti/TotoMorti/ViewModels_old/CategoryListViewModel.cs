using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using TotoMorti.Classes;
using TotoMorti.Managers;
using TotoMorti.Models;

namespace TotoMorti.ViewModels
{
    public class CategoryListViewModel : BindableBase, INavigationAware
    {
        private readonly CelebrityManager _celebrityManager;
        private readonly INavigationService _navigationService;
        private TotoList _currentTotoList;

        public CategoryListViewModel(INavigationService navigationService, CelebrityManager celebrityManager)
        {
            _navigationService = navigationService;
            _celebrityManager = celebrityManager;
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
            {
                CurrentTotoList = (TotoList) parameters["totoList"];
                foreach (var category in CurrentTotoList.Categories)
                    category.ResolvedCelebrityList = _celebrityManager.ResolveCelebrityList(category,
                        CurrentTotoList.ListGuid);
            }
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