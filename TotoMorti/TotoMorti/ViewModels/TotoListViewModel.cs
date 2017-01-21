using System;
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
    public class TotoListViewModel : BaseNavigationViewModel
    {
        private readonly TotoListManager _totoListManager;

        private Command _addTotoListCommand;
        private Command<TotoList> _deleteCommand;
        private Command<TotoList> _editCommand;
        private ObservableCollection<TotoList> _totoListList;
        private Command<TotoList> _viewTotoListCommand;

        public TotoListViewModel(TotoListManager totoListManager)
        {
            _totoListManager = totoListManager;
            EventCenter.OnTotoListFormSaved += OnTotoListFormSaved;
            LoadContext();
        }

        private void OnTotoListFormSaved(TotoList totoList)
        {
            var t = TotoListList.FirstOrDefault(x => x.ListGuid == totoList.ListGuid);
            if (t != null)
            {
                var i = TotoListList.IndexOf(t);
                if (i >= 0)
                {
                    TotoListList.Remove(t);
                    TotoListList.Insert(i, totoList);
                }
                else
                {
                    TotoListList.Add(totoList);
                }
                RaisePropertyChanged(() => TotoListList);
            }
        }

        public ObservableCollection<TotoList> TotoListList
        {
            get { return _totoListList; }
            set
            {
                _totoListList = value;
                RaisePropertyChanged(() => TotoListList);
            }
        }

        public Command AddTotoListCommand
        {
            get
            {
                return _addTotoListCommand ??
                       (_addTotoListCommand = new Command(async () => await NavigateAddTotoList()));
            }
        }


        public Command<TotoList> DeleteCommand
        {
            get
            {
                return _deleteCommand ??
                       (_deleteCommand = new Command<TotoList>(async t => await DeleteTotoList(t)));
            }
        }

        public Command<TotoList> EditCommand
        {
            get
            {
                return _editCommand ??
                       (_editCommand = new Command<TotoList>(async t => await NavigateEditTotoList(t)));
            }
        }

        public Command<TotoList> ViewTotoListCommand
        {
            get
            {
                return _viewTotoListCommand ??
                       (_viewTotoListCommand = new Command<TotoList>(async t => await NavigateViewTotoList(t)));
            }
        }


        private void LoadContext()
        {
            Task.Run(() => TotoListList = new ObservableCollection<TotoList>(_totoListManager.GetAllTotoLists()));
        }

        private async Task NavigateAddTotoList()
        {
            var p = new NamedParameter("fs", FormStatus.Add);
            await PushAsync(Bootstrapper.IoCContainer.Resolve<TotoListFormPage>(p));
        }

        private async Task NavigateViewTotoList(TotoList list)
        {
            var p = new NamedParameter("totolist", list);
            await PushAsync(Bootstrapper.IoCContainer.Resolve<CategoryListPage>(p));
        }

        private async Task NavigateEditTotoList(TotoList list)
        {
            var p = new Parameter[]
            {
                new NamedParameter("fs", FormStatus.Edit),
                new NamedParameter("totolist", list)
            };
            await PushAsync(Bootstrapper.IoCContainer.Resolve<TotoListFormPage>(p));
        }

        private async Task DeleteTotoList(TotoList t)
        {
            await _totoListManager.DeleteTotoList(t);
            LoadContext();
        }
    }
}