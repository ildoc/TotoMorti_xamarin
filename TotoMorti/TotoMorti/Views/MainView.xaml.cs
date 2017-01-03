using System;
using Xamarin.Forms;

namespace TotoMorti.Views
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();
        }

        private async void ShowAbout(object sender, EventArgs e)
        {
            const string changelog = "03/01/2017\n" +
                                     "- Aggiunto tasto About\n" +
                                     "\n" +
                                     "31/12/2016\n" +
                                     "- Prima release funzionante";

            await DisplayAlert("About",changelog, "OK");
        }
    }
}