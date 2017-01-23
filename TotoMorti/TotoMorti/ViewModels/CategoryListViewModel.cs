using System;
using System.Linq;
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
        private readonly TotoListManager _totoListManager;
        private Guid _listGuid;

        public CategoryListViewModel(CategoryManager categoryManager, CelebrityManager celebrityManager, TotoListManager totoListManager)
        {
            _categoryManager = categoryManager;
            _celebrityManager = celebrityManager;
            _totoListManager = totoListManager;
            EventCenter.OnCategoryFormSaved += OnCategoryFormSaved;
        }

        private void OnCategoryFormSaved(Category cat)
        {
            LoadContext();
            //var c = CurrentTotoList.Categories.FirstOrDefault(x => x.CategoryGuid == cat.CategoryGuid);

            //var i = CurrentTotoList.Categories.IndexOf(c);
            //if (i >= 0)
            //{
            //    CurrentTotoList.Categories.Remove(c);
            //    CurrentTotoList.Categories.Insert(i, cat);
            //}
            //else
            //{
            //    CurrentTotoList.Categories.Add(cat);
            //}
            //RaisePropertyChanged(() => CurrentTotoList.Categories);
        }

        public TotoList CurrentTotoList
        {
            get { return _currentTotoList; }
            set
            {
                _currentTotoList = value;
                RaisePropertyChanged(() => CurrentTotoList);
            }
        }

        public Command<Category> DeleteCommand => _deleteCommand ??
                                                  (_deleteCommand = new Command<Category>(DeleteCategory));

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
            _listGuid = totolist.ListGuid;            
            LoadContext();
        }

        private void DeleteCategory(Category c)
        {
            var cat = CurrentTotoList.Categories.FirstOrDefault(x => x.CategoryGuid == c.CategoryGuid);
            if (cat != null)
                CurrentTotoList.Categories.Remove(cat);

            _categoryManager.DeleteCategory(c, CurrentTotoList.ListGuid);
            LoadContext();
        }

        private void LoadContext()
        {
            CurrentTotoList = _totoListManager.GetTotoList(_listGuid);
            foreach (var category in CurrentTotoList.Categories)
                category.ResolvedCelebrityList = _celebrityManager.ResolveCelebrityList(category,
                    CurrentTotoList.ListGuid);
            
        }
    }
}