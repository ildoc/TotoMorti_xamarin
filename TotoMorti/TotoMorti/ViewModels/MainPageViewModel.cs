using System.Threading.Tasks;
using Autofac;
using TotoMorti.Pages;
using TotoMorti.ViewModels.Abstracts;
using Xamarin.Forms;

namespace TotoMorti.ViewModels
{
    public class MainPageViewModel : BaseNavigationViewModel
    {
        public string Changelog = TotoMorti.Changelog.Changes;
        private Command _celebrityListCommand;
        private IContainer _iContainer;
        public MainPageViewModel(IContainer iContainer)
        {
            _iContainer = iContainer;
        }

        private Command CelebrityListCommand
        {
            get
            {
                return _celebrityListCommand ??
                       (_celebrityListCommand = new Command(async () => await ExecutedCelebrityListCommand()));
            }
        }

        private async Task ExecutedCelebrityListCommand()
        {
            await PushAsync(_iContainer.Resolve<CelebrityListPage>());
        }
    }


  
}