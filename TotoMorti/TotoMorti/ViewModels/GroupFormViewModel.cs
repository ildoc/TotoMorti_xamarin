using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using TotoMorti.Classes;
using TotoMorti.Extensions;
using TotoMorti.Managers;

namespace TotoMorti.ViewModels
{
    public class GroupFormViewModel : BindableBase, INavigationAware
    {
        private readonly GroupManager _groupManager;
        private readonly INavigationService _navigationService;
        private readonly SessionManager _sessionManager;
        // public string ButtonText { get; set; }
        private string _buttonText;

        private FormStatus _currentFormStatus;

        private Group _currentGroup;

        public GroupFormViewModel(INavigationService navigationService, GroupManager groupManager,
            SessionManager sessionManager)
        {
            _navigationService = navigationService;
            _groupManager = groupManager;
            _sessionManager = sessionManager;
            SaveFormCommand = new DelegateCommand(SaveForm, CanSaveForm);
        }

        public Group CurrentGroup
        {
            get { return _currentGroup; }
            set { SetProperty(ref _currentGroup, value); }
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
                        CurrentGroup = _sessionManager.CurrentUser.CreateNewGroup();
                        break;

                    case FormStatus.Edit:
                        if (parameters.ContainsKey("group"))
                            CurrentGroup = (Group) parameters["group"];
                        break;
                }
            }
        }

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

        private bool CanSaveForm()
        {
            return true;
        }

        private void SaveForm()
        {
            switch (CurrentFormStatus)
            {
                case FormStatus.Add:
                    _groupManager.AddGroup(CurrentGroup);
                    _navigationService.GoBackAsync();
                    break;

                case FormStatus.Edit:
                    break;
            }
        }
    }
}