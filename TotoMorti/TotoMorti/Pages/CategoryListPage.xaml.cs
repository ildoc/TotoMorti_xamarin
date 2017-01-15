using TotoMorti.Models;
using TotoMorti.ViewModels;
using Xamarin.Forms;

namespace TotoMorti.Pages
{
    public partial class CategoryListPage : ContentPage
    {
        public CategoryListPage(CategoryListViewModel vm, TotoList totolist = null)
        {
            InitializeComponent();
            vm.InitializeParameters(totolist);
            BindingContext = vm;
        }
    }
}