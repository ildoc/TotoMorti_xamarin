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
            set
            {
                _currentCelebrity = value;
                RaisePropertyChanged(() => CurrentCelebrity);
            }
        }

        public Command SaveCommand

        {
            get

            {
                return _saveCommand ??
                       (_saveCommand = new Command(() => SaveForm()));
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

        private async void SaveForm()
        {
            _celebrityManager.SaveCelebrity(CurrentCelebrity);
            await PopAsync();
            EventCenter.CelebrityAdded(CurrentCelebrity);
        }
    }
}