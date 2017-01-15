using System;
using System.Collections.Generic;
using TotoMorti.Models;
using TotoMorti.ViewModels;
using Xamarin.Forms;

namespace TotoMorti.Pages
{
    public partial class AvailableCelebrityListPage : ContentPage
    {
        private readonly AvailableCelebrityListViewModel _vm;

        public AvailableCelebrityListPage(AvailableCelebrityListViewModel vm, List<Celebrity> selectedCelebrities,
            Category category, Guid listGuid)
        {
            InitializeComponent();
            _vm = vm;
            _vm.InitializeParameters(selectedCelebrities, category, listGuid);
            BindingContext = _vm;
        }

        private void List_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (_vm.AddCelebrityCommand.CanExecute((Celebrity) e.Item))
                _vm.AddCelebrityCommand.Execute((Celebrity) e.Item);
        }
    }
}