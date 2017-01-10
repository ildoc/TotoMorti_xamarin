using System.Threading.Tasks;
using TotoMorti.Resx;
using TotoMorti.ViewModels;
using Xamarin.Forms;

namespace TotoMorti.Pages
{
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var _ShouldDelayForSplash = true;
            if (_ShouldDelayForSplash)
                // delay for a few seconds on the splash screen
                await Task.Delay(3000);

            // if a data partition phrase has not yet been set
            //if (string.IsNullOrWhiteSpace(Settings.DataPartitionPhrase))
            //{
            //    // modally push a new SetupPage wrapped in a NavigationPage
            //    var navPage = new NavigationPage(new SetupPage())
            //    {
            //        BarBackgroundColor = Color.FromHex("547799")
            //    };

            //    navPage.BarTextColor = Color.White;

            //    await Navigation.PushModalAsync(navPage);

            //    _ShouldDelayForSplash = false;
            //}
            //else
            //{
            // create a new NavigationPage, with a new AcquaintanceListPage set as the Root
            var navPage = new NavigationPage(
                new MainPage
                {
                    BindingContext = new MainPageViewModel(),
                    Title = AppResources.AppName
                });

            navPage.BarTextColor = Color.White;

            // set the MainPage of the app to the navPage
            Application.Current.MainPage = navPage;
            //}
        }
    }
}