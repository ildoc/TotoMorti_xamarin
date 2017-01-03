using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using TotoMorti.Classes;
using TotoMorti.Managers;

namespace TotoMorti.ViewModels
{
    public class TotoListListViewModel: BindableBase, INavigationAware
    {
        private readonly TotoListManager _totoListManager;
        private readonly INavigationService _navigationService;
        private ObservableCollection<TotoList> _totoListList;

        public TotoListListViewModel(INavigationService navigationService, TotoListManager totoListManager)
        {
            _navigationService = navigationService;
            _totoListManager = totoListManager;
            AddTotoListCommand = new DelegateCommand(AddTotoList);
            OnDeleteCommand = new DelegateCommand<TotoList>(DeleteTotoList);
            OnViewCommand = new DelegateCommand<TotoList>(ViewTotoList);
            OnEditCommand = new DelegateCommand<TotoList>(EditTotoList);
            // SaveCommand = new DelegateCommand(Save);
           
        }

        private void ViewTotoList(TotoList obj)
        {
            var p = new NavigationParameters { { "categoryList", obj.Categories } };

            _navigationService.NavigateAsync(PageNames.CategoryListFormView, p);
        }

        private void EditTotoList(TotoList obj)
        {
            var p = new NavigationParameters { { "totolist", obj } };

            _navigationService.NavigateAsync(PageNames.TotoListFormView, p);
        }

        public DelegateCommand<TotoList> OnEditCommand { get; set; }

        public DelegateCommand<TotoList> OnViewCommand { get; set; }

        private void DeleteTotoList(TotoList obj)
        {
            throw new NotImplementedException();
        }

        public DelegateCommand<TotoList> OnDeleteCommand { get; set; }

        private void AddTotoList()
        {
            throw new NotImplementedException();
        }

        public DelegateCommand AddTotoListCommand { get; set; }
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
          
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            TotoListList = new ObservableCollection<TotoList>(_totoListManager.GetAllTotoLists());
        }

        public ObservableCollection<TotoList> TotoListList
        {
            get { return _totoListList; }
            set { SetProperty(ref  _totoListList, value); }
        }
    }
    }

