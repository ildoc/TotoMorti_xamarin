using Prism.Unity;
using TotoMorti.Classes;
using TotoMorti.Views;

namespace TotoMorti
{
    public class App : PrismApplication
    {
        // https://evolve.xamarin.com/session/56e2211afd00c0253cae33a9
        // https://github.com/brianlagunas/Evolve2016SamplesAndSlides

        public App(IPlatformInitializer initializer = null) : base(initializer)
        {
        }

        protected override void OnInitialized()
        {
            NavigationService.NavigateAsync("MainView");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainView>();
            Container.RegisterTypeForNavigation<EditCelebrityView>();
            Container.RegisterTypeForNavigation<CelebrityListView>();
        }

        protected override void OnStart()
        {
            Current.Properties["CurrentUser"] = new User();
        }
    }
}
