using Microsoft.Practices.Unity;
using Prism.Unity;
using TotoMorti.Classes;
using TotoMorti.Interfaces;
using TotoMorti.Managers;
using TotoMorti.Views;

namespace TotoMorti
{
    public class App : PrismApplication
    {
        // https://evolve.xamarin.com/session/56e2211afd00c0253cae33a9
        // https://github.com/brianlagunas/Evolve2016SamplesAndSlides

        public IAuthentication Authentication;

        public App(IPlatformInitializer initializer = null) : base(initializer)
        {
        }

        public static string AppName { get { return "TotoMorti"; } }

        protected override void OnInitialized()
        {
            NavigationService.NavigateAsync(PageNames.MainView);
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainView>(PageNames.MainView);
            Container.RegisterTypeForNavigation<CelebrityFormView>(PageNames.CelebrityFormView);
            Container.RegisterTypeForNavigation<CelebrityListView>(PageNames.CelebrityListView);
            Container.RegisterTypeForNavigation<GroupListView>();
            Container.RegisterTypeForNavigation<LoginView>();
        }

        private void RegisterManagers()
        {
            Container.RegisterType(typeof(CelebrityManager), typeof(CelebrityManager), null, new ContainerControlledLifetimeManager());
        }

        protected override void OnStart()
        {
            Current.Properties["CurrentUser"] = new User();
        }
    }
}
