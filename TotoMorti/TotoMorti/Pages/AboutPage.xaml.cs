using System;
using Xamarin.Forms;

namespace TotoMorti.Pages
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private async void ShowAbout(object sender, EventArgs e)
        {
            await DisplayAlert("About", Changelog.Changes, "OK");
        }

        private void ShowDonations(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri(@"https://www.paypal.me/ildoc/5"));
        }
    }
}