using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace Hsking.Mobile.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private MvxCommand _navigateToRegisterCommand;

        public ICommand NavigateToRegisterCommand
        {
            get
            {
                _navigateToRegisterCommand = _navigateToRegisterCommand ?? new MvxCommand(NavigateToRegister);
                return _navigateToRegisterCommand;
            }
        }

        public MainViewModel()
        {
            
        }

        private void NavigateToRegister()
        {
            ShowViewModel<RegisterViewModel>();
        }
    }
}
