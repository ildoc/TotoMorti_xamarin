using TotoMorti.Classes;
using TotoMorti.Models;
using TotoMorti.ViewModels;
using Xamarin.Forms;

namespace TotoMorti.Pages
{
    public partial class CategoryFormPage : ContentPage
    {
        public CategoryFormPage(CategoryFormViewModel vm, FormStatus fs, TotoList totolist, Category category = null)
        {
            InitializeComponent();
            vm.InitializeParameters(fs, totolist, category);
            BindingContext = vm;
        }
    }
}