using System;
using TotoMorti.ViewModels;
using Xamarin.Forms;

namespace TotoMorti.Pages
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel _vm;

        public MainPage(MainPageViewModel vm)
        {
            InitializeComponent();
            _vm = vm;
            BindingContext = _vm;
        }


        private async void ShowAbout(object sender, EventArgs e)
        {
            await DisplayAlert("About", _vm.Changelog, "OK");
        }
    }
}