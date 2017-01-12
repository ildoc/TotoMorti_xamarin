using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotoMorti.Managers;
using TotoMorti.ViewModels.Abstracts;

namespace TotoMorti.ViewModels
{
    public class CelebrityListViewModel:BaseNavigationViewModel
    {
        private CelebrityManager _celebrityManager;
        public CelebrityListViewModel(CelebrityManager celebrityManager)
        {
            _celebrityManager = celebrityManager;
            LoadContext();
        }

        private async Task LoadContext()
        {
            
        }
    }
}
