using TotoMorti.Models;
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

        private void List_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (_vm.ViewTotoListCommand.CanExecute((TotoList) e.Item))
                _vm.ViewTotoListCommand.Execute((TotoList) e.Item);
        }
    }
}