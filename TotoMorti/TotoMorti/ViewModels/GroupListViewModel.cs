using System.Collections.Generic;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using TotoMorti.Classes;
using TotoMorti.Managers;

namespace TotoMorti.ViewModels
{
    public class GroupListViewModel : BindableBase, INavigationAware
    {
        private readonly GroupManager _groupManager;
        private readonly INavigationService _navigationService;
        private List<Group> _groupList;

        private Group _selectedGroup;

        public GroupListViewModel(INavigationService navigationService, GroupManager groupManager)
        {
            _navigationService = navigationService;
            _groupManager = groupManager;
            CreateGroupCommand = new DelegateCommand(NavigateAddGroup, CanNavigateAddGroup);
            LeaveGroupCommand = new DelegateCommand<Group>(LeaveGroup);
        }

        public DelegateCommand<Group> LeaveGroupCommand { get; set; }

        public Group SelectedGroup
        {
            get { return _selectedGroup; }
            set
            {
                if (_selectedGroup != value)
                {
                    SetProperty(ref _selectedGroup, value);
                    NavigateViewGroup();
                }
            }
        }

        private void NavigateViewGroup()
        {
            var p = new NavigationParameters { {"group", SelectedGroup } };
            _navigationService.NavigateAsync(PageNames.GroupDetailView, p);
        }

        public List<Group> GroupList
        {
            get { return _groupList; }
            set { SetProperty(ref _groupList, value); }
        }

        public DelegateCommand CreateGroupCommand { get; private set; }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            GroupList = _groupManager.GetAllGroups();
        }

        private void LeaveGroup(Group g)
        {
        }

        private void NavigateAddGroup()
        {
            var p = new NavigationParameters {{"action", FormStatus.Add}};

            _navigationService.NavigateAsync(PageNames.GroupFormView, p);
        }

        private bool CanNavigateAddGroup()
        {
            return true;
        }
    }
}