﻿using System.Collections.Generic;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using TotoMorti.Classes;

namespace TotoMorti.ViewModels
{
    public class CelebrityListViewModel : BindableBase
    {
        private INavigationService _navigationService;

        public CelebrityListViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            EditCelebrityCommand = new DelegateCommand(NavigateEditCelebrity, CanNavigateEditCelebrity);
            AddCelebrityCommand = new DelegateCommand(NavigateAddCelebrity, CanNavigateAddCelebrity);
        }

        private void NavigateAddCelebrity()
        {
            var p = new NavigationParameters();
            p.Add("action", "add");

            _navigationService.NavigateAsync("EditCelebrityView", p);
        }

        private bool CanNavigateAddCelebrity()
        {
            return true;
        }

        private bool CanNavigateEditCelebrity()
        {
            return true;
        }

        private List<Celebrity> _celebrityList = new List<Celebrity>
        {
           new Celebrity {Name="Kirk", Surname="Douglas", ImageUrl="http://cdn.inquisitr.com/wp-content/uploads/2014/12/kirk-douglas-100x100.jpg" },
           new Celebrity {Name="Beppe", Surname="Bigazzi", ImageUrl="http://www.newnotizie.it/wp-content/uploads/2010/02/bigazzi-100x100.jpg" },
           new Celebrity {Name="Valentino", Surname="Rossi", ImageUrl="http://www.litalianews.it/wp-content/uploads/2015/08/MotoGp-Valentino-Rossi-100x100.jpg" }
        };

        public List<Celebrity> CelebrityList
        {
            get { return _celebrityList; }
            set { SetProperty(ref _celebrityList, value); }
        }

        private void NavigateEditCelebrity()
        {
            var p = new NavigationParameters();
            p.Add("action", "edit");

            _navigationService.NavigateAsync("EditCelebrityView", p);
        }

        public DelegateCommand EditCelebrityCommand { get; private set; }
        public DelegateCommand AddCelebrityCommand { get; private set; }
    }
}
