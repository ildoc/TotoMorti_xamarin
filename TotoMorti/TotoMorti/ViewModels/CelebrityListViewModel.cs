using System.Collections.Generic;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using TotoMorti.Classes;
using TotoMorti.Managers;

namespace TotoMorti.ViewModels
{
    public class CelebrityListViewModel : BindableBase, INavigationAware
    {
        private readonly CelebrityManager _celebrityManager;
        private readonly INavigationService _navigationService;
        private List<Celebrity> _celebrityList;

        private Celebrity _selectedCelebrity;

        public CelebrityListViewModel(INavigationService navigationService, CelebrityManager celebrityManager)
        {
            _navigationService = navigationService;
            _celebrityManager = celebrityManager;
            AddCelebrityCommand = new DelegateCommand(NavigateAddCelebrity, CanNavigateAddCelebrity);
        }

        public Celebrity SelectedCelebrity
        {
            get { return _selectedCelebrity; }
            set
            {
                if (_selectedCelebrity != value)
                {
                    SetProperty(ref _selectedCelebrity, value);
                    NavigateEditCelebrity();
                }
            }
        }

        public List<Celebrity> CelebrityList
        {
            get { return _celebrityList; }
            set { SetProperty(ref _celebrityList, value); }
        }

        public DelegateCommand AddCelebrityCommand { get; private set; }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            CelebrityList = _celebrityManager.GetAllCelebrities();
        }

        private void NavigateAddCelebrity()
        {
            var p = new NavigationParameters {{"action", FormStatus.Add}};

            _navigationService.NavigateAsync(PageNames.CelebrityFormView, p);
        }

        private bool CanNavigateAddCelebrity()
        {
            return true;
        }

        private void NavigateEditCelebrity()
        {
            var p = new NavigationParameters {{"action", FormStatus.Edit}, {"celebrity", SelectedCelebrity}};

            _navigationService.NavigateAsync(PageNames.CelebrityFormView, p);
        }
    }
}