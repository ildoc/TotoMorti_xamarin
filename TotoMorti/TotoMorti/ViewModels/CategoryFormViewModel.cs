using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using TotoMorti.Classes;
using TotoMorti.Managers;
using TotoMorti.Models;
using TotoMorti.Pages;
using TotoMorti.ViewModels.Abstracts;
using Xamarin.Forms;

namespace TotoMorti.ViewModels
{
    public class CategoryFormViewModel : BaseNavigationViewModel
    {
        private readonly CategoryManager _categoryManager;
        private Command _addCommand;
        private Category _currentCategory;
        private Command<Celebrity> _deleteCommand;
        private Guid _listGuid;
        private Command _saveCommand;
        private List<Celebrity> _selectedCelebrityList;

        public CategoryFormViewModel(CategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
            SelectedCelebrityList = new List<Celebrity>();
        }

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

        public Command SaveCommand => _saveCommand ??
                                      (_saveCommand = new Command(SaveForm));

        public Command AddCommand => _addCommand ??
                                     (_addCommand = new Command(AddCelebrity));

        public Command<Celebrity> DeleteCommand => _deleteCommand ??
                                                   (_deleteCommand = new Command<Celebrity>(RemoveCelebrity));

        private void RemoveCelebrity(Celebrity c)
        {
            _categoryManager.RemoveCelebrityFromCategory(c, CurrentCategory, _listGuid);
        }

        private async void AddCelebrity()
        {
            var p = new Parameter[]
            {
                new NamedParameter("selectedCelebrities", SelectedCelebrityList),
                new NamedParameter("category", _currentCategory),
                new NamedParameter("listGuid", _listGuid)
            };

            await PushAsync(Bootstrapper.IoCContainer.Resolve<AvailableCelebrityListPage>(p));
        }

        public void InitializeParameters(FormStatus fs, TotoList t, Category c)
        {
            _listGuid = t.ListGuid;
            switch (fs)
            {
                case FormStatus.Add:
                    CurrentCategory = new Category();
                    break;

                case FormStatus.Edit:
                    CurrentCategory = c;
                    break;
            }

            LoadSelectedCelebrities();
        }

        private void SaveForm()
        {
            _categoryManager.SaveCategory(CurrentCategory, _listGuid);
        }

        private void LoadSelectedCelebrities()
        {
            SelectedCelebrityList = _categoryManager.GetCelebritiesByGuid(CurrentCategory.CelebrityList);
        }
    }
}