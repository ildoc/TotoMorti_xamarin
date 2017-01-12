using System;
using TotoMorti.Classes;
using TotoMorti.Models;
using TotoMorti.ViewModels;
using Xamarin.Forms;

namespace TotoMorti.Pages
{
    public partial class CelebrityFormPage : ContentPage
    {
        public CelebrityFormPage(CelebrityFormViewModel vm, FormStatus fs, Celebrity celebrity = null)
        {
            InitializeComponent();
            vm.InitializeParameters(fs, celebrity);
            BindingContext = vm;
        }

        private void CelebrityFormPage_OnDisappearing(object sender, EventArgs e)
        {
            EventCenter.CelebrityFormClosed();
        }
    }
}