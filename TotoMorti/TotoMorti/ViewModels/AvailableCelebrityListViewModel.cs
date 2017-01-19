using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using TotoMorti.Classes;
using TotoMorti.Managers;
using TotoMorti.Models;
using TotoMorti.ViewModels.Abstracts;
using Xamarin.Forms;

namespace TotoMorti.ViewModels
{
    public class AvailableCelebrityListViewModel : BaseNavigationViewModel
    {
        private readonly CategoryManager _categoryManager;
        private readonly CelebrityManager _celebrityManager;
        private Command<Celebrity> _addCelebrityCommand;
        private List<Celebrity> _availableCelebrities;
        private Category _category;
        private Guid _listGuid;

        public AvailableCelebrityListViewModel(CelebrityManager celebrityManager, CategoryManager categoryManager)
        {
            _celebrityManager = celebrityManager;
            _categoryManager = categoryManager;
        }

        public List<Celebrity> AvailableCelebrities
        {
            get { return _availableCelebrities; }
            set
            {
                _availableCelebrities = value;
                RaisePropertyChanged(() => AvailableCelebrities);
            }
        }

        public Command<Celebrity> AddCelebrityCommand => _addCelebrityCommand ??
                                                         (_addCelebrityCommand = new Command<Celebrity>(AddCelebrity));


        public void InitializeParameters(List<Celebrity> selectedCelebrities, Category category, Guid listGuid)
        {
            _category = category;
            _listGuid = listGuid;
            AvailableCelebrities =
                _celebrityManager.GetAvailableCelebrities(selectedCelebrities);
        }

        private async void AddCelebrity(Celebrity c)
        {
            _category.CelebrityList.Add(c.CelebrityGuid.ToString());
            _categoryManager.SaveCategory(_category, _listGuid);
            var p = new Parameter[]
            {
                new NamedParameter("action", FormStatus.Edit),
                new NamedParameter("listGuid", _listGuid),
                new NamedParameter("category", _category)
            };
            await PopAsync();
        }
    }
}