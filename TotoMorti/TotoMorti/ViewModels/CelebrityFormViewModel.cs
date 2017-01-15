using System.Threading.Tasks;
using TotoMorti.Classes;
using TotoMorti.Managers;
using TotoMorti.Models;
using TotoMorti.ViewModels.Abstracts;
using Xamarin.Forms;

namespace TotoMorti.ViewModels
{
    public class CelebrityFormViewModel : BaseNavigationViewModel
    {
        private readonly CelebrityManager _celebrityManager;
        private Celebrity _currentCelebrity;
        private Command _saveCommand;

        public CelebrityFormViewModel(CelebrityManager celebrityManager)
        {
            _celebrityManager = celebrityManager;
        }

        public Celebrity CurrentCelebrity
        {
            get { return _currentCelebrity; }
            set { SetProperty(ref _currentCelebrity, value); }
        }

        public Command SaveCommand
        {
            get
            {
                return _saveCommand ??
                       (_saveCommand = new Command(async () => await SaveForm()));
            }
        }

        public void InitializeParameters(FormStatus fs, Celebrity c)
        {
            switch (fs)
            {
                case FormStatus.Add:
                    CurrentCelebrity = new Celebrity();
                    break;

                case FormStatus.Edit:
                    CurrentCelebrity = c;
                    break;
            }
        }

        private async Task SaveForm()
        {
            await _celebrityManager.SaveCelebrity(CurrentCelebrity);
            await PopAsync();
        }
    }
}