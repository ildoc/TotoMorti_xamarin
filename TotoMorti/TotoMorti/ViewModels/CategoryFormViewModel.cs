using System;
using System.Collections.Generic;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using TotoMorti.Classes;
using TotoMorti.Managers;
using TotoMorti.Models;
using TotoMorti.Resx;

namespace TotoMorti.ViewModels
{
    public class CategoryFormViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private Category _currentCategory;
        private FormStatus _currentFormStatus;
        private readonly JsonDbManager _jsonDbManager;
        private Guid _listGuid;
        private List<Celebrity> _selectedCelebrityList;

        public CategoryFormViewModel(INavigationService navigationService, JsonDbManager jsonDbManager)
        {
            _navigationService = navigationService;
            _jsonDbManager = jsonDbManager;
            AddCommand = new DelegateCommand(AddCelebrity);
            SelectedCelebrityList = new List<Celebrity>();
        }

        public DelegateCommand AddCommand { get; set; }

        public List<Celebrity> SelectedCelebrityList
        {
            get { return _selectedCelebrityList; }
            set { SetProperty(ref _selectedCelebrityList, value); }
        }

        public Category CurrentCategory
        {
            get { return _currentCategory; }
            set { SetProperty(ref _currentCategory, value); }
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

        public string ButtonText { get; set; }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("action") && parameters.ContainsKey("listGuid"))
            {
                CurrentFormStatus = (FormStatus) parameters["action"];
                _listGuid = (Guid) parameters["listGuid"];

                switch (CurrentFormStatus)
                {
                    case FormStatus.Add:
                        CurrentCategory = new Category();
                        break;

                    case FormStatus.Edit:
                        if (parameters.ContainsKey("category"))
                            CurrentCategory = (Category) parameters["category"];
                        break;
                }
            }

            SelectedCelebrityList = _jsonDbManager.GetCelebritiesByGuid(CurrentCategory.CelebrityList);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        private void AddCelebrity()
        {
            var p = new NavigationParameters
            {
                {"selectedCelebrities", SelectedCelebrityList},
                {"category", CurrentCategory},
                {"listGuid", _listGuid}
            };

            _navigationService.NavigateAsync(PageNames.AvailableCelebrityListView, p);
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
    }
}