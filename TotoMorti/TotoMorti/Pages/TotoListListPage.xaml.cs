using TotoMorti.ViewModels;
using Xamarin.Forms;

namespace TotoMorti.Pages
{
    public partial class TotoListListPage : ContentPage
    {
        private readonly TotoListViewModel _vm;

        public TotoListListPage(TotoListViewModel vm)
        {
            InitializeComponent();
            _vm = vm;
            BindingContext = _vm;
        }
    }
}