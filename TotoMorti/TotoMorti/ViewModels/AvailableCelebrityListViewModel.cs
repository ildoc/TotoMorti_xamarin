using System;
using System.Collections.Generic;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using TotoMorti.Classes;
using TotoMorti.Managers;
using TotoMorti.Models;

namespace TotoMorti.ViewModels
{
    public class AvailableCelebrityListViewModel : BindableBase, INavigationAware
    {
        private readonly JsonDbManager _jsonDbManager;
        private readonly INavigationService _navigationService;
        private List<Celebrity> _availableCelebrities;
        private Category _category;
        private Guid _listGuid;
        private Celebrity _selectedCelebrity;

        public AvailableCelebrityListViewModel(INavigationService navigationService, JsonDbManager jsonDbManager)
        {
            _navigationService = navigationService;
            _jsonDbManager = jsonDbManager;
            AddCommand = new DelegateCommand(AddCelebrities);
        }

        public Celebrity SelectedCelebrity
        {
            get { return _selectedCelebrity; }
            set
            {
                if (_selectedCelebrity != value)
                {
                    SetProperty(ref _selectedCelebrity, value);
                    _category.CelebrityList.Add(SelectedCelebrity.CelebrityGuid.ToString());
                    _jsonDbManager.SaveCategory(_category, _listGuid);
                    var p = new NavigationParameters
                    {
                        {"action", FormStatus.Edit},
                        {"listGuid", _listGuid},
                        {"category", _category}
                    };

                    _navigationService.GoBackAsync(p);
                }
            }
        }

        public List<Celebrity> AvailableCelebrities
        {
            get { return _availableCelebrities; }
            set { SetProperty(ref _availableCelebrities, value); }
        }

        public DelegateCommand AddCommand { get; set; }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("selectedCelebrities") && parameters.ContainsKey("category") &&
                parameters.ContainsKey("listGuid"))
            {
                _listGuid = (Guid) parameters["listGuid"];
                _category = (Category) parameters["category"];

                AvailableCelebrities =
                    _jsonDbManager.GetAvailableCelebrities((List<Celebrity>) parameters["selectedCelebrities"]);
            }
        }

        private void AddCelebrities()
        {
            throw new NotImplementedException();
        }
    }
}