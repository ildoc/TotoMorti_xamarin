﻿using System;
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
            const string changelog = "00/01/2017\n" +
                                     "- Modifiche flow creazione liste\n" +
                                     "- Abilitata possibilità inserimento Vip\n" +
                                     "- Modifiche alla grafica\n" +
                                     "\n" +
                                     "04/01/2017\n" +
                                     "- Pubblicazione su Play Store\n" +
                                     "- Aggiunta possibilità di avere più liste\n" +
                                     "- Migliorata grafica (poco)\n" +
                                     "- Aggiunta icona\n" +
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