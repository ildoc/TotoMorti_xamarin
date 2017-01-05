using Microsoft.Practices.Unity;
using Prism.Unity;
using TotoMorti.Classes;
using TotoMorti.Managers;
using TotoMorti.Views;

namespace TotoMorti
{
    public class App : PrismApplication
    {
        // https://evolve.xamarin.com/session/56e2211afd00c0253cae33a9
        // https://github.com/brianlagunas/Evolve2016SamplesAndSlides

        public static string AppName => "TotoMorti";

        protected override void OnInitialized()
        {
            //NavigationService.NavigateAsync(PageNames.LoginView);
            NavigationService.NavigateAsync(PageNames.MainView);
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<LoginView>(PageNames.LoginView);
            Container.RegisterTypeForNavigation<RegisterView>(PageNames.RegisterView);
            Container.RegisterTypeForNavigation<MainView>(PageNames.MainView);
            Container.RegisterTypeForNavigation<CelebrityFormView>(PageNames.CelebrityFormView);
            Container.RegisterTypeForNavigation<CelebrityListView>(PageNames.CelebrityListView);
            Container.RegisterTypeForNavigation<TotoListListView>(PageNames.GroupListView);
            Container.RegisterTypeForNavigation<GroupDetailView>(PageNames.GroupDetailView);
            Container.RegisterTypeForNavigation<GroupFormView>(PageNames.GroupFormView);
            Container.RegisterTypeForNavigation<CategoryListFormView>(PageNames.CategoryListFormView);
            Container.RegisterTypeForNavigation<TotoListListView>(PageNames.TotoListListView);
            Container.RegisterTypeForNavigation<TotoListFormView>(PageNames.TotoListFormView);

            //Container.RegisterType(typeof(CelebrityManager), typeof(CelebrityManager), null,
            //    new ContainerControlledLifetimeManager());
            //Container.RegisterType(typeof(GroupManager), typeof(GroupManager), null,
            //    new ContainerControlledLifetimeManager());
            Container.RegisterType(typeof(CategoryManager), typeof(CategoryManager), null,
                new ContainerControlledLifetimeManager());
            Container.RegisterType(typeof(TotoListManager), typeof(TotoListManager), null,
                new ContainerControlledLifetimeManager());
            Container.RegisterType(typeof(JsonDbManager), typeof(JsonDbManager), null,
                new ContainerControlledLifetimeManager());
        }
    }
}