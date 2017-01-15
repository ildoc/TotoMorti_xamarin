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
        private Command _showAboutCommand;
        private Command _totoListListCommand;
        public string Changelog = TotoMorti.Changelog.Changes;

        public Command CelebrityListCommand
        {
            get
            {
                return _celebrityListCommand ??
                       (_celebrityListCommand = new Command(async () => await NavigateCelebrityListCommand()));
            }
        }

        public Command TotoListListCommand
        {
            get
            {
                return _totoListListCommand ??
                       (_totoListListCommand = new Command(async () => await NavigateTotoListListCommand()));
            }
        }

        public Command ShowAboutCommand
        {
            get
            {
                return _showAboutCommand ??
                       (_showAboutCommand = new Command(async () => await NavigateAboutCommand()));
            }
        }

        private async Task NavigateTotoListListCommand()
        {
            await PushAsync(Bootstrapper.IoCContainer.Resolve<TotoListListPage>());
        }

        private async Task NavigateCelebrityListCommand()
        {
            await PushAsync(Bootstrapper.IoCContainer.Resolve<CelebrityListPage>());
        }

        private async Task NavigateAboutCommand()
        {
            await PushAsync(Bootstrapper.IoCContainer.Resolve<AboutPage>());
        }
    }
}