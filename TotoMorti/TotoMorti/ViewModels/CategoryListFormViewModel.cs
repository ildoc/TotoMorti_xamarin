using System.Collections.ObjectModel;
using System.Linq;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using TotoMorti.Classes;
using TotoMorti.Managers;

namespace TotoMorti.ViewModels
{
    public class CategoryListFormViewModel : BindableBase, INavigationAware
    {
        private readonly CategoryManager _categoryManager;
        private ObservableCollection<Category> _categoryList;
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
            CategoryList = new ObservableCollection<Category>(_categoryManager.GetAllCategories());
        }

        private void Save()
        {
            _categoryManager.SaveCategoryList(CategoryList.ToList());
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