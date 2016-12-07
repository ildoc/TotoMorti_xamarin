﻿using Microsoft.Practices.Unity;
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
            NavigationService.NavigateAsync(PageNames.LoginView);
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<LoginView>(PageNames.LoginView);
            Container.RegisterTypeForNavigation<RegisterView>(PageNames.RegisterView);
            Container.RegisterTypeForNavigation<MainView>(PageNames.MainView);
            Container.RegisterTypeForNavigation<CelebrityFormView>(PageNames.CelebrityFormView);
            Container.RegisterTypeForNavigation<CelebrityListView>(PageNames.CelebrityListView);
            Container.RegisterTypeForNavigation<GroupListView>(PageNames.GroupListView);
            Container.RegisterTypeForNavigation<GroupDetailView>(PageNames.GroupDetailView);
            Container.RegisterTypeForNavigation<GroupFormView>(PageNames.GroupFormView);

            Container.RegisterType(typeof(CelebrityManager), typeof(CelebrityManager), null,
                new ContainerControlledLifetimeManager());
            Container.RegisterType(typeof(GroupManager), typeof(GroupManager), null,
                new ContainerControlledLifetimeManager());
        }

        protected override void OnStart()
        {
            Current.Properties["CurrentUser"] = new User();
        }
    }
}