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
            const string changelog = "00/00/0000\n" +
                                     "- Aggiunta possibilità di avere più liste\n" +
                                     "- Migliorata grafica (poco)" +
                                     "\n" +
                                     "03/01/2017\n" +
                                     "- Aggiunto tasto About\n" +
                                     "\n" +
                                     "31/12/2016\n" +
                                     "- Prima release funzionante\n" +
                                     "- Aggiunte traduzioni";

            await DisplayAlert("About", changelog, "OK");
        }
    }
}