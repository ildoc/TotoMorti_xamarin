using FormsToolkit;
using TotoMorti.Constants;
using TotoMorti.Pages;
using TotoMorti.Resx;
using TotoMorti.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace TotoMorti
{
    public partial class App : Application
    {
        //https://github.com/xamarinhq/app-acquaint

        public App()
        {
            InitializeComponent();
            SubscribeToDisplayAlertMessages();

            // The navigation logic startup needs to diverge per platform in order to meet the UX design requirements
            if (Device.OS == TargetPlatform.Android)
            {
                // if this is an Android device, set the MainPage to a new SplashPage
                MainPage = new SplashPage();
            }
            else
            {
                // create a new NavigationPage, with a new AcquaintanceListPage set as the Root
                var navPage =
                    new NavigationPage(
                        new MainPage
                        {
                            BindingContext = new MainPageViewModel(),
                            Title = AppResources.AppName
                        })
                    {
                        BarBackgroundColor = Color.FromHex("547799")
                    };

                navPage.BarTextColor = Color.White;

                // set the MainPage of the app to the navPage
                MainPage = navPage;
            }
        }

        /// <summary>
        ///     Subscribes to messages for displaying alerts.
        /// </summary>
        private static void SubscribeToDisplayAlertMessages()
        {
            MessagingService.Current.Subscribe<MessagingServiceAlert>(MessageKeys.DisplayAlert, async (service, info) =>
            {
                var task = Current?.MainPage?.DisplayAlert(info.Title, info.Message, info.Cancel);
                if (task != null)
                {
                    await task;
                    info?.OnCompleted?.Invoke();
                }
            });

            MessagingService.Current.Subscribe<MessagingServiceQuestion>(MessageKeys.DisplayQuestion,
                async (service, info) =>
                {
                    var task = Current?.MainPage?.DisplayAlert(info.Title, info.Question, info.Positive, info.Negative);
                    if (task != null)
                    {
                        var result = await task;
                        info?.OnCompleted?.Invoke(result);
                    }
                });
        }
    }
}