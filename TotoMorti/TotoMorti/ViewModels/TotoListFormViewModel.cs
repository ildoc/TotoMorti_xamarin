using Autofac;
using TotoMorti.Classes;
using TotoMorti.Managers;
using TotoMorti.Models;
using TotoMorti.Pages;
using TotoMorti.ViewModels.Abstracts;
using Xamarin.Forms;

namespace TotoMorti.ViewModels
{
    public class TotoListFormViewModel : BaseNavigationViewModel
    {
        private readonly TotoListManager _totoListManager;
        private TotoList _currentTotoList;

        private Command _saveCommand;

        public TotoListFormViewModel(TotoListManager totoListManager)
        {
            _totoListManager = totoListManager;
        }

        public Command SaveCommand => _saveCommand ??
                                      (_saveCommand = new Command(SaveForm));

        public TotoList CurrentTotoList
        {
            get { return _currentTotoList; }
            set { SetProperty(ref _currentTotoList, value); }
        }

        private async void SaveForm()
        {
            _totoListManager.SaveTotoList(CurrentTotoList);
            var p = new NamedParameter("totolist", CurrentTotoList);
            await PushAsync(Bootstrapper.IoCContainer.Resolve<CategoryListPage>(p));
        }

        public void InitializeParameters(FormStatus fs, TotoList t = null)
        {
            switch (fs)
            {
                case FormStatus.Add:
                    CurrentTotoList = new TotoList();
                    break;

                case FormStatus.Edit:
                    CurrentTotoList = t;
                    break;
            }
        }
    }
}