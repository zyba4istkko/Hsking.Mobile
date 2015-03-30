using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using Hsking.Mobile.ViewModels.Base;

namespace Hsking.Mobile.ViewModels
{
    public class StartViewModel : LoadingScreen
    {
        private List<int> _pages;
        private int _selectedPage;
        private MvxCommand _navigateToRegisterCommand;

   

        private List<HskingTask> _tasks;

        public List<int> Pages
        {
            get { return _pages; }
            set { _pages = value; }
        }

        public ICommand NavigateToRegisterCommand
        {
            get
            {
                _navigateToRegisterCommand = _navigateToRegisterCommand ?? new MvxCommand(NavigateToRegister);
                return _navigateToRegisterCommand;
            }
        }

        private void NavigateToRegister()
        {
            ShowViewModel<RegisterViewModel>();
        }

        public int SelectedPage
        {
            get { return _selectedPage; }
            set
            {
                _selectedPage = value;
                base.RaisePropertyChanged(()=>SelectedPage);
            }
        }

        public List<HskingTask> Tasks
        {
            get { return _tasks; }
        }

        public StartViewModel()
        {
            _pages = new List<int>() { 1, 2,  };
            _tasks=new List<HskingTask>();
            Tasks.Add(new HskingTask() { Icon = "\xf085", Description = "Создаёт условия для выработки привычки" });
            Tasks.Add(new HskingTask() { Icon = "\xf079", Description = "Помогает довести привычкидо автоматизма" });
            Tasks.Add(new HskingTask() { Icon = "\xf084", Description = "Делится секретом и тем,как начать им пользоваться" });
        }
    }

    public class HskingTask
    {
        public string Icon { get; set; }
        public string Description { get; set; }
    }
}
