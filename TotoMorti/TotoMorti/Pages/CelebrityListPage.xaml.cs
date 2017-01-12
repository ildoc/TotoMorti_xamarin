using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotoMorti.ViewModels;
using Xamarin.Forms;

namespace TotoMorti.Pages
{
    public partial class CelebrityListPage : ContentPage
    {
        public CelebrityListPage(CelebrityListViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}
