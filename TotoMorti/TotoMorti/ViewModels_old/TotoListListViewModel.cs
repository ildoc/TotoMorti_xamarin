using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using TotoMorti.Classes;
using TotoMorti.Managers;
using TotoMorti.Models;

namespace TotoMorti.ViewModels
{
    public class TotoListListViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private readonly TotoListManager _totoListManager;
        private ObservableCollection<TotoList> _totoListList;

        public TotoListListViewModel(INavigationService navigationService, TotoListManager totoListManager)
        {
            _navigationService = navigationService;
            _totoListManager = totoListManager;
            AddTotoListCommand = new DelegateCommand(AddTotoList);
            OnDeleteCommand = new DelegateCommand<TotoList>(DeleteTotoList);
            OnViewCommand = new DelegateCommand<TotoList>(ViewTotoList);
            OnEditCommand = new DelegateCommand<TotoList>(EditTotoList);
        }

        public DelegateCommand<TotoList> OnEditCommand { get; set; }

        public DelegateCommand<TotoList> OnViewCommand { get; set; }

        public DelegateCommand<TotoList> OnDeleteCommand { get; set; }

        public DelegateCommand AddTotoListCommand { get; set; }

        public ObservableCollection<TotoList> TotoListList
        {
            get { return _totoListList; }
            set { SetProperty(ref _totoListList, value); }
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            LoadLists();
        }

        private void LoadLists()
        {
            TotoListList = new ObservableCollection<TotoList>(_totoListManager.GetAllTotoLists());
        }

        private void ViewTotoList(TotoList obj)
        {
            var p = new NavigationParameters {{"totoList", obj}};

            _navigationService.NavigateAsync(PageNames.CategoryListView, p);
        }

        private void EditTotoList(TotoList obj)
        {
            var p = new NavigationParameters {{"action", FormStatus.Edit}, {"totolist", obj}};

            _navigationService.NavigateAsync(PageNames.TotoListFormView, p);
        }

        private void DeleteTotoList(TotoList obj)
        {
            _totoListManager.DeleteTotoList(obj);
            LoadLists();
        }

        private void AddTotoList()
        {
            var p = new NavigationParameters {{"action", FormStatus.Add}};

            _navigationService.NavigateAsync(PageNames.TotoListFormView, p);
        }
    }
}