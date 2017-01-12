using Android.App;
using Android.Content.PM;
using Android.OS;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Microsoft.Practices.ServiceLocation;
using TotoMorti.Droid.API;
using TotoMorti.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace TotoMorti.Droid
{
    [Activity(Label = "TotoMorti", Icon = "@drawable/icon", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        private IContainer _IoCContainer;

        protected override void OnCreate(Bundle bundle)
        {
            //RegisterDependencies();

            ToolbarResource = Resource.Layout.toolbar;

            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        private void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<JsonDb_Android>().As<IJsonDb>();

            _IoCContainer = builder.Build();

            var csl = new AutofacServiceLocator(_IoCContainer);
            ServiceLocator.SetLocatorProvider(() => csl);
        }
    }
}