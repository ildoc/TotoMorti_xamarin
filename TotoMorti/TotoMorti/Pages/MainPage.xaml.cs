using System;
using TotoMorti.ViewModels;
using Xamarin.Forms;

namespace TotoMorti.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected MainPageViewModel ViewModel => BindingContext as MainPageViewModel;

        private async void ShowAbout(object sender, EventArgs e)
        {
            await DisplayAlert("About", ViewModel.Changelog, "OK");
        }
    }
}