using Prism.Mvvm;
using Prism.Navigation;

namespace TotoMorti.ViewModels
{
    public class EditCelebrityViewModel : BindableBase, INavigationAware
    {
        private INavigationService _navigationService;

        public EditCelebrityViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        private string testText;

        public string TestText
        {
            get { return testText; }
            set { SetProperty(ref testText, value); }
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("action"))
            {
                switch ((string)parameters["action"])
                {
                    case "add":
                        TestText = "add";
                        break;

                    case "edit":
                        TestText = "edit";
                        break;
                }
            }
        }
    }
}
