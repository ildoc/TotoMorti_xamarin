using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using TotoMorti.Classes;

namespace TotoMorti.ViewModels
{
    public class CelebrityFormViewModel : BindableBase, INavigationAware
    {
        private INavigationService _navigationService;

        private Celebrity _currentCelebrity;

        public Celebrity CurrentCelebrity
        {
            get { return _currentCelebrity; }
            set { SetProperty(ref _currentCelebrity, value); }
        }

        public string ButtonText { get; set; }

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

        public CelebrityFormViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            SaveFormCommand = new DelegateCommand(SaveForm, CanSaveForm);
        }

        private bool CanSaveForm()
        {
            return true;
        }

        private void SaveForm()
        {
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

                        break;

                    case "edit":
                        if (parameters.ContainsKey("celebrity"))
                        {
                            CurrentCelebrity = (Celebrity)parameters["celebrity"];
                        }

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
