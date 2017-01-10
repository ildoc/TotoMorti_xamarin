using TotoMorti.ViewModels.Abstracts;

namespace TotoMorti.ViewModels
{
    public class MainPageViewModel : BaseNavigationViewModel
    {
        public string Changelog = TotoMorti.Changelog.Changes;
    }
}