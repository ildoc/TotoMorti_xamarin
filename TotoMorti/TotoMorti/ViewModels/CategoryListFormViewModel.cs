using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using TotoMorti.Classes;
using TotoMorti.Managers;
using TotoMorti.Models;

namespace TotoMorti.ViewModels
{
    public class CategoryListFormViewModel : BindableBase, INavigationAware
    {
        private readonly CategoryManager _categoryManager;
        private ObservableCollection<Category> _categoryList;
        private Guid _listGuid;
        private INavigationService _navigationService;

        public CategoryListFormViewModel(INavigationService navigationService, CategoryManager categoryManager)
        {
            _navigationService = navigationService;

            _categoryManager = categoryManager;
            AddCategoryCommand = new DelegateCommand(AddCategory);
            OnDeleteCommand = new DelegateCommand<Category>(DeleteCategory);
            SaveCommand = new DelegateCommand(Save);
            CategoryList = new ObservableCollection<Category>();
        }

        public DelegateCommand SaveCommand { get; set; }

        public DelegateCommand<Category> OnDeleteCommand { get; set; }

        public DelegateCommand AddCategoryCommand { get; set; }

        public ObservableCollection<Category> CategoryList
        {
            get { return _categoryList; }
            set { SetProperty(ref _categoryList, value); }
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("categoryList") && parameters.ContainsKey("listGuid"))
            {
                _listGuid = (Guid) parameters["listGuid"];
                CategoryList = new ObservableCollection<Category>((List<Category>) parameters["categoryList"]);
            }
        }

        private void Save()
        {
            _categoryManager.SaveCategoryList(CategoryList.ToList(), _listGuid);
        }

        private void DeleteCategory(Category cat)
        {
            CategoryList.Remove(cat);
        }

        private void AddCategory()
        {
            CategoryList.Add(new Category());
        }
    }
}