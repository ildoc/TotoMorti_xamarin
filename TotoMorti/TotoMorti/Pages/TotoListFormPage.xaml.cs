using TotoMorti.Classes;
using TotoMorti.Models;
using TotoMorti.ViewModels;
using Xamarin.Forms;

namespace TotoMorti.Pages
{
    public partial class TotoListFormPage : ContentPage
    {
        public TotoListFormPage(TotoListFormViewModel vm, FormStatus fs, TotoList totolist = null)
        {
            InitializeComponent();
            vm.InitializeParameters(fs, totolist);
            BindingContext = vm;
        }
    }
}