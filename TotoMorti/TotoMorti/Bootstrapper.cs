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

            builder.RegisterType<SplashPage>();
            builder.RegisterType<MainPage>();
            builder.RegisterType<AboutPage>();
            builder.RegisterType<CelebrityListPage>().SingleInstance();
            builder.RegisterType<CelebrityFormPage>();
            builder.RegisterType<TotoListListPage>().SingleInstance();
            builder.RegisterType<TotoListFormPage>();
            builder.RegisterType<CategoryListPage>();
            builder.RegisterType<CategoryFormPage>();
            builder.RegisterType<AvailableCelebrityListPage>();

            builder.RegisterType<MainPageViewModel>().SingleInstance();
            builder.RegisterType<CelebrityListViewModel>().SingleInstance();
            builder.RegisterType<CelebrityFormViewModel>().SingleInstance();
            builder.RegisterType<TotoListViewModel>().SingleInstance();
            builder.RegisterType<TotoListFormViewModel>().SingleInstance();
            builder.RegisterType<CategoryListViewModel>().SingleInstance();
            builder.RegisterType<CategoryFormViewModel>().SingleInstance();
            builder.RegisterType<AvailableCelebrityListViewModel>().SingleInstance();

            builder.RegisterType<JsonDbManager>().SingleInstance();
            builder.RegisterType<CelebrityManager>().SingleInstance();
            builder.RegisterType<CategoryManager>().SingleInstance();
            builder.RegisterType<TotoListManager>().SingleInstance();

            builder.RegisterInstance(DependencyService.Get<IJsonDb>());

            IoCContainer = builder.Build();

            var csl = new AutofacServiceLocator(IoCContainer);
            ServiceLocator.SetLocatorProvider(() => csl);
        }
    }
}