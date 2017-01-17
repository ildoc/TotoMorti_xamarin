using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using TotoMorti.Classes;
using TotoMorti.Managers;
using TotoMorti.Models;
using TotoMorti.Pages;
using TotoMorti.ViewModels.Abstracts;
using Xamarin.Forms;

namespace TotoMorti.ViewModels
{
    public class CelebrityListViewModel : BaseNavigationViewModel
    {
        private readonly CelebrityManager _celebrityManager;

        private Command _addCelebrityCommand;
        private ObservableCollection<Celebrity> _celebrityList;
        private Command<Celebrity> _deleteCommand;
        private Command<Celebrity> _editCelebrityCommand;
        private Command _refreshCelebrityListCommand;

        public CelebrityListViewModel(CelebrityManager celebrityManager)
        {
            EventCenter.OnAddedCelebrity += OnAddedCelebrity;
            _celebrityManager = celebrityManager;
            LoadContext();
        }

        public ObservableCollection<Celebrity> CelebrityList
        {
            get { return _celebrityList; }
            set { SetProperty(ref _celebrityList, value); }
        }

        public Command AddCelebrityCommand
        {
            get
            {
                return _addCelebrityCommand ??
                       (_addCelebrityCommand = new Command(async () => await NavigateAddCelebrity()));
            }
        }


        public Command<Celebrity> DeleteCommand
        {
            get
            {
                return _deleteCommand ??
                       (_deleteCommand = new Command<Celebrity>(async c => await DeleteCelebrity(c)));
            }
        }

        public Command RefreshCelebrityListCommand
        {
            get
            {
                return _refreshCelebrityListCommand ??
                       (_refreshCelebrityListCommand ?? new Command(() => RefreshContext()));
            }
        }

        public Command<Celebrity> EditCelebrityCommand
        {
            get
            {
                return _editCelebrityCommand ??
                       (_editCelebrityCommand = new Command<Celebrity>(async c => await NavigateEditCelebrity(c)));
            }
        }

        private void RefreshContext()
        {
            IsBusy = true;
            LoadContext();
            IsBusy = false;
        }

        private void OnAddedCelebrity(Celebrity cel)
        {
            var c = CelebrityList.FirstOrDefault(x => x.CelebrityGuid == cel.CelebrityGuid);

            var i = CelebrityList.IndexOf(c);
            if (i >= 0)
            {
                CelebrityList.Remove(c);
                CelebrityList.Insert(i, cel);
            }
            else
                CelebrityList.Add(cel);
            OnPropertyChanged("CelebrityList");
        }

        private void LoadContext()
        {
            Task.Run(() => CelebrityList = new ObservableCollection<Celebrity>( _celebrityManager.GetAllCelebrities())).Wait();
        }

        private async Task NavigateAddCelebrity()
        {
            var p = new NamedParameter("fs", FormStatus.Add);
            await PushAsync(Bootstrapper.IoCContainer.Resolve<CelebrityFormPage>(p));
        }

        private async Task NavigateEditCelebrity(Celebrity celebrity)
        {
            var p = new Parameter[]
            {
                new NamedParameter("fs", FormStatus.Edit),
                new NamedParameter("celebrity", celebrity)
            };
            await PushAsync(Bootstrapper.IoCContainer.Resolve<CelebrityFormPage>(p));
        }

        private async Task DeleteCelebrity(Celebrity c)
        {
            await _celebrityManager.DeleteCelebrity(c);
            LoadContext();
        }
    }
}