using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.Generic;
using TotoMorti.Classes;
using TotoMorti.Managers;

namespace TotoMorti.ViewModels
{
    public class CelebrityListViewModel : BindableBase, INavigationAware
    {
        private INavigationService _navigationService;
        private CelebrityManager _celebrityManager;

        private Celebrity _selectedCelebrity;

        public Celebrity SelectedCelebrity
        {
            get
            {
                return _selectedCelebrity;
            }
            set
            {
                if (_selectedCelebrity != value)
                {
                    SetProperty(ref _selectedCelebrity, value);
                    NavigateEditCelebrity();
                }
            }
        }

        public CelebrityListViewModel(INavigationService navigationService, CelebrityManager celebrityManager)
        {
            _navigationService = navigationService;
            _celebrityManager = celebrityManager;
            AddCelebrityCommand = new DelegateCommand(NavigateAddCelebrity, CanNavigateAddCelebrity);
        }

        private void NavigateAddCelebrity()
        {
            var p = new NavigationParameters();
            p.Add("action", "add");

            _navigationService.NavigateAsync(PageNames.CelebrityFormView, p);
        }

        private bool CanNavigateAddCelebrity()
        {
            return true;
        }

        private List<Celebrity> _celebrityList;

        public List<Celebrity> CelebrityList
        {
            get { return _celebrityList; }
            set { SetProperty(ref _celebrityList, value); }
        }

        private void NavigateEditCelebrity()
        {
            var p = new NavigationParameters();
            p.Add("action", "edit");
            p.Add("celebrity", SelectedCelebrity);

            _navigationService.NavigateAsync(PageNames.CelebrityFormView, p);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            CelebrityList = _celebrityManager.GetAllCelebrities();
        }

        public DelegateCommand AddCelebrityCommand { get; private set; }
    }
}
