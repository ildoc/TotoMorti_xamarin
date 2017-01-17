using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Microsoft.Practices.ServiceLocation;
using TotoMorti.Interfaces;
using TotoMorti.Managers;
using TotoMorti.Pages;
using TotoMorti.ViewModels;
using Xamarin.Forms;

namespace TotoMorti
{
    public static class Bootstrapper
    {
        public static IContainer IoCContainer;

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<SplashPage>().AsSelf();
            builder.RegisterType<MainPage>().AsSelf();
            builder.RegisterType<AboutPage>().AsSelf();
            builder.RegisterType<CelebrityListPage>().AsSelf();
            builder.RegisterType<CelebrityFormPage>().AsSelf();
            builder.RegisterType<TotoListListPage>().AsSelf();
            builder.RegisterType<TotoListFormPage>().AsSelf();
            builder.RegisterType<CategoryListPage>().AsSelf();
            builder.RegisterType<CategoryFormPage>().AsSelf();
            builder.RegisterType<AvailableCelebrityListPage>().AsSelf();

            builder.RegisterType<MainPageViewModel>().AsSelf();
            builder.RegisterType<CelebrityListViewModel>().AsSelf();
            builder.RegisterType<CelebrityFormViewModel>().AsSelf();
            builder.RegisterType<TotoListViewModel>().AsSelf();
            builder.RegisterType<TotoListFormViewModel>().AsSelf();
            builder.RegisterType<CategoryListViewModel>().AsSelf();
            builder.RegisterType<CategoryFormViewModel>().AsSelf();
            builder.RegisterType<AvailableCelebrityListViewModel>().AsSelf();

            builder.RegisterType<JsonDbManager>().AsSelf();
            builder.RegisterType<CelebrityManager>().AsSelf();
            builder.RegisterType<CategoryManager>().AsSelf();
            builder.RegisterType<TotoListManager>().AsSelf();

            builder.RegisterInstance(DependencyService.Get<IJsonDb>());

            IoCContainer = builder.Build();

            var csl = new AutofacServiceLocator(IoCContainer);
            ServiceLocator.SetLocatorProvider(() => csl);
        }
    }
}