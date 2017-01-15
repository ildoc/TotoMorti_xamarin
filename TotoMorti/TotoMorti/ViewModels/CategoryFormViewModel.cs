using System;
using System.Threading.Tasks;
using TotoMorti.Classes;
using TotoMorti.Managers;
using TotoMorti.Models;
using TotoMorti.ViewModels.Abstracts;
using Xamarin.Forms;

namespace TotoMorti.ViewModels
{
    public class CategoryFormViewModel : BaseNavigationViewModel
    {
        private readonly CategoryManager _categoryManager;
        private Category _currentCategory;
        private Guid _listGuid;
        private Command _saveCommand;

        public CategoryFormViewModel(CategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public Category CurrentCategory
        {
            get { return _currentCategory; }
            set { SetProperty(ref _currentCategory, value); }
        }

        public Command SaveCommand
        {
            get
            {
                return _saveCommand ??
                       (_saveCommand = new Command(async () => await SaveForm()));
            }
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
        }

        private async Task SaveForm()
        {
            await _categoryManager.SaveCategory(CurrentCategory, _listGuid);
        }
    }
}