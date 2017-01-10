using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using TotoMorti.Classes;
using TotoMorti.Managers;
using TotoMorti.Models;

namespace TotoMorti.ViewModels
{
    public class CelebrityListViewModel : BindableBase, INavigationAware
    {
        private readonly CelebrityManager _celebrityManager;
        private readonly INavigationService _navigationService;
        private ObservableCollection<Celebrity> _celebrityList;

        private Celebrity _selectedCelebrity;

        public CelebrityListViewModel(INavigationService navigationService, CelebrityManager celebrityManager)
        {
            _navigationService = navigationService;
            _celebrityManager = celebrityManager;
            AddCelebrityCommand = new DelegateCommand(NavigateAddCelebrity, CanNavigateAddCelebrity);
            OnDeleteCommand = new DelegateCommand<Celebrity>(DeleteCelebrity);
        }

        public DelegateCommand<Celebrity> OnDeleteCommand { get; set; }

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

        public ObservableCollection<Celebrity> CelebrityList
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
            LoadCelebrities();
        }

        private void DeleteCelebrity(Celebrity obj)
        {
            _celebrityManager.DeleteCelebrity(obj);
            LoadCelebrities();
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

        private void LoadCelebrities()
        {
            CelebrityList = new ObservableCollection<Celebrity>(_celebrityManager.GetAllCelebrities());
        }
    }
}