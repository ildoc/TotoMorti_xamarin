using System.Threading.Tasks;
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
    public class CategoryListViewModel : BaseNavigationViewModel
    {
        private readonly CategoryManager _categoryManager;
        private readonly CelebrityManager _celebrityManager;
        private Command _addCommand;
        private TotoList _currentTotoList;
        private Command<Category> _deleteCommand;
        private Command<Category> _editCommand;

        public CategoryListViewModel(CategoryManager categoryManager, CelebrityManager celebrityManager)
        {
            _categoryManager = categoryManager;
            _celebrityManager = celebrityManager;
        }

        public TotoList CurrentTotoList
        {
            get { return _currentTotoList; }
            set { SetProperty(ref _currentTotoList, value); }
        }

        public Command<Category> DeleteCommand
        {
            get
            {
                return _deleteCommand ??
                       (_deleteCommand = new Command<Category>(async c => await DeleteCategory(c)));
            }
        }

        public Command AddCommand
        {
            get
            {
                return _addCommand ??
                       (_addCommand = new Command(async () => await AddCategory()));
            }
        }

        public Command<Category> EditCommand
        {
            get
            {
                return _editCommand ??
                       (_editCommand = new Command<Category>(async c => await EditCategory(c)));
            }
        }

        private async Task EditCategory(Category c)
        {
            var p = new Parameter[]
            {
                new NamedParameter("fs", FormStatus.Edit),
                new NamedParameter("category", c),
                new NamedParameter("totolist", CurrentTotoList)
            };

            await PushAsync(Bootstrapper.IoCContainer.Resolve<CategoryFormPage>(p));
        }

        private async Task AddCategory()
        {
            var p = new Parameter[]
            {
                new NamedParameter("fs", FormStatus.Add),
                new NamedParameter("totolist", CurrentTotoList)
            };

            await PushAsync(Bootstrapper.IoCContainer.Resolve<CategoryFormPage>(p));
        }

        public void InitializeParameters(TotoList totolist)
        {
            CurrentTotoList = totolist;
            foreach (var category in CurrentTotoList.Categories)
                category.ResolvedCelebrityList = _celebrityManager.ResolveCelebrityList(category,
                    CurrentTotoList.ListGuid);
        }

        private async Task DeleteCategory(Category c)
        {
            await _categoryManager.DeleteCategory(c, CurrentTotoList.ListGuid);
            CurrentTotoList.Categories.Remove(c);
        }

        private void LoadContext()
        {
            //CurrentTotoList  = 
        }
    }
}