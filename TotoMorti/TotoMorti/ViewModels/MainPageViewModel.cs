using System.Threading.Tasks;
using Autofac;
using TotoMorti.Pages;
using TotoMorti.ViewModels.Abstracts;
using Xamarin.Forms;

namespace TotoMorti.ViewModels
{
    public class MainPageViewModel : BaseNavigationViewModel
    {
        private Command _celebrityListCommand;
        public string Changelog = TotoMorti.Changelog.Changes;

        public Command CelebrityListCommand
        {
            get
            {
                return _celebrityListCommand ??
                       (_celebrityListCommand = new Command(async () => await NavigateCelebrityListCommand()));
            }
        }

        private async Task NavigateCelebrityListCommand()
        {
            await PushAsync(Bootstrapper.IoCContainer.Resolve<CelebrityListPage>());
        }
    }
}