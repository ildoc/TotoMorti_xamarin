using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using TotoMorti.Classes;
using TotoMorti.Managers;

namespace TotoMorti.ViewModels
{
    public class CelebrityFormViewModel : BindableBase, INavigationAware
    {
        private INavigationService _navigationService;
        private CelebrityManager _celebrityManager;

        private Celebrity _currentCelebrity;

        public Celebrity CurrentCelebrity
        {
            get { return _currentCelebrity; }
            set { SetProperty(ref _currentCelebrity, value); }
        }

        // public string ButtonText { get; set; }
        private string _buttonText;

        public string ButtonText
        {
            get { return _buttonText; }
            set { SetProperty(ref _buttonText, value); }
        }

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

        public DelegateCommand SaveFormCommand { get; private set; }

        private void ChangeFormStatus(FormStatus fs)
        {
            switch (fs)
            {
                case FormStatus.Add:
                    ButtonText = "add";
                    break;

                case FormStatus.Edit:
                    ButtonText = "edit";
                    break;
            }
        }

        public CelebrityFormViewModel(INavigationService navigationService, CelebrityManager celebrityManager)
        {
            _navigationService = navigationService;
            _celebrityManager = celebrityManager;
            SaveFormCommand = new DelegateCommand(SaveForm, CanSaveForm);
        }

        private bool CanSaveForm()
        {
            return true;
        }

        private void SaveForm()
        {
            switch (CurrentFormStatus)
            {
                case FormStatus.Add:
                    _celebrityManager.AddCelebrity(CurrentCelebrity);
                    _navigationService.GoBackAsync();
                    break;

                case FormStatus.Edit:
                    break;
            }
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
                        CurrentCelebrity = new Celebrity();
                        CurrentFormStatus = FormStatus.Add;
                        break;

                    case "edit":
                        if (parameters.ContainsKey("celebrity"))
                        {
                            CurrentCelebrity = (Celebrity)parameters["celebrity"];
                        }
                        CurrentFormStatus = FormStatus.Edit;
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
