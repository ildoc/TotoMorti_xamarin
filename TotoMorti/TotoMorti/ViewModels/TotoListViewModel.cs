using TotoMorti.Managers;
using TotoMorti.ViewModels.Abstracts;

namespace TotoMorti.ViewModels
{
    public class TotoListViewModel : BaseNavigationViewModel
    {
        private TotoListManager _totoListManager;

        public TotoListViewModel(TotoListManager totoListManager)
        {
            _totoListManager = totoListManager;
        }
    }
}