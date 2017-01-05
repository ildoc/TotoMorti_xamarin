using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using TotoMorti.Classes;
using TotoMorti.Managers;
using TotoMorti.Resx;

namespace TotoMorti.ViewModels
{
    public class CelebrityFormViewModel : BindableBase, INavigationAware
    {
        private readonly CelebrityManager _celebrityManager;
        private readonly INavigationService _navigationService;
        // public string ButtonText { get; set; }
        private string _buttonText;

        private Celebrity _currentCelebrity;

        private FormStatus _currentFormStatus;

        public CelebrityFormViewModel(INavigationService navigationService, CelebrityManager celebrityManager)
        {
            _navigationService = navigationService;
            _celebrityManager = celebrityManager;
            SaveFormCommand = new DelegateCommand(SaveForm, CanSaveForm);
        }

        public Celebrity CurrentCelebrity
        {
            get { return _currentCelebrity; }
            set { SetProperty(ref _currentCelebrity, value); }
        }

        public string ButtonText
        {
            get { return _buttonText; }
            set { SetProperty(ref _buttonText, value); }
        }

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

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("action"))
                CurrentFormStatus = (FormStatus) parameters["action"];
            {
                switch (CurrentFormStatus)
                {
                    case FormStatus.Add:
                        CurrentCelebrity = new Celebrity();
                        break;

                    case FormStatus.Edit:
                        if (parameters.ContainsKey("celebrity"))
                            CurrentCelebrity = (Celebrity) parameters["celebrity"];
                        break;
                }
            }
        }

        private void ChangeFormStatus(FormStatus fs)
        {
            switch (fs)
            {
                case FormStatus.Add:
                    ButtonText = AppResources.ButtonAdd;
                    break;

                case FormStatus.Edit:
                    ButtonText = AppResources.ButtonEdit;
                    break;
            }
        }

        private bool CanSaveForm()
        {
            return true;
        }

        private void SaveForm()
        {
                    _celebrityManager.SaveCelebrity(CurrentCelebrity);
        }
    }
}