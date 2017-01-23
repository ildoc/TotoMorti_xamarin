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
    }
}