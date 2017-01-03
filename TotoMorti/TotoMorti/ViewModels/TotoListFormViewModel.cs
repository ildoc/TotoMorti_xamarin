using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using TotoMorti.Classes;
using TotoMorti.Managers;
using TotoMorti.Resx;

namespace TotoMorti.ViewModels
{
    internal class TotoListFormViewModel : BindableBase, INavigationAware
    {
        private readonly JsonDbManager _jsonDbManager;
        private readonly INavigationService _navigationService;


        private string _buttonText;

        private FormStatus _currentFormStatus;

        private TotoList _currentTotoList;

        public TotoListFormViewModel(INavigationService navigationService, JsonDbManager jsonDbManager)
        {
            _navigationService = navigationService;
            _jsonDbManager = jsonDbManager;
            SaveCommand = new DelegateCommand(SaveForm, CanSaveForm);
        }

        public TotoList CurrentTotoList
        {
            get { return _currentTotoList; }
            set { SetProperty(ref _currentTotoList, value); }
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

        public DelegateCommand SaveCommand { get; private set; }

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
                        CurrentTotoList = new TotoList();
                        break;

                    case FormStatus.Edit:
                        if (parameters.ContainsKey("totolist"))
                            CurrentTotoList = (TotoList) parameters["totolist"];
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
            _jsonDbManager.SaveTotoList(CurrentTotoList);

            var p = new NavigationParameters
            {
                {"categoryList", CurrentTotoList.Categories},
                {"listGuid", CurrentTotoList.ListGuid}
            };

            _navigationService.NavigateAsync(PageNames.CategoryListFormView, p);
        }
    }
}