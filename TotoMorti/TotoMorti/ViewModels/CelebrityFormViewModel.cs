using Prism.Mvvm;
using Prism.Navigation;

namespace TotoMorti.ViewModels
{
    public class CelebrityFormViewModel : BindableBase, INavigationAware
    {
        private INavigationService _navigationService;

        private FormStatus _currentFormStatus;

        private FormStatus CurrentFormStatus
        {
            get { return _currentFormStatus; }
            set
            {
                _currentFormStatus = value;
                ChangeFormStatus(value);
            }
        }

        private void ChangeFormStatus(FormStatus fs)
        {
            switch (fs)
            {
                case FormStatus.Add:
                    break;

                case FormStatus.Edit:
                    break;
            }
        }

        public CelebrityFormViewModel(INavigationService navigationService)
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

    internal enum FormStatus
    {
        Add,
        Edit
    }
}
