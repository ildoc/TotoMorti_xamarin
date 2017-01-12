using TotoMorti.Models;
using TotoMorti.ViewModels;
using Xamarin.Forms;

namespace TotoMorti.Pages
{
    public partial class CelebrityListPage : ContentPage
    {
        private readonly CelebrityListViewModel _vm;

        public CelebrityListPage(CelebrityListViewModel vm)
        {
            InitializeComponent();
            _vm = vm;
            BindingContext = _vm;
        }


        private void List_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (_vm.EditCelebrityCommand.CanExecute((Celebrity) e.Item))
                _vm.EditCelebrityCommand.Execute((Celebrity) e.Item);
        }
    }
}