using System.Threading.Tasks;
using TotoMorti.Pages;
using TotoMorti.ViewModels.Abstracts;
using Xamarin.Forms;

namespace TotoMorti.ViewModels
{
    public class MainPageViewModel : BaseNavigationViewModel
    {
        public string Changelog = TotoMorti.Changelog.Changes;
        private Command _celebrityListCommand;


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
            await PushAsync(new CelebrityListPage() { BindingContext = new CelebrityListViewModel() });
        }
    }


  
}