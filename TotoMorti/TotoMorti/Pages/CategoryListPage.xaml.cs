using TotoMorti.Models;
using TotoMorti.ViewModels;
using Xamarin.Forms;

namespace TotoMorti.Pages
{
    public partial class CategoryListPage : ContentPage
    {
        private readonly CategoryListViewModel _vm;

        public CategoryListPage(CategoryListViewModel vm, TotoList totolist = null)
        {
            InitializeComponent();
            _vm = vm;
            _vm.InitializeParameters(totolist);
            BindingContext = _vm;
        }
    }
}