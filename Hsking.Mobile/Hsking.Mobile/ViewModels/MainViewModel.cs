using System.Diagnostics;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using Hsking.Mobile.Api;
using Hsking.Mobile.ViewModels.Base;

namespace Hsking.Mobile.ViewModels
{
    public class MainViewModel : LoadingScreen
    {
        private readonly IApiSettings _apiSettings;
        private MvxCommand _navigateToStartCommand;

        public ICommand NavigateToStartCommand
        {
            get
            {
                _navigateToStartCommand = _navigateToStartCommand ?? new MvxCommand(NavigateToStart);
                return _navigateToStartCommand;
            }
        }

        public MainViewModel(IApiSettings apiSettings)
        {
            _apiSettings = apiSettings;
            Debug.WriteLine(_apiSettings.SavedToken);
        }

        private void NavigateToStart()
        {
            ShowViewModel<StartViewModel>();
        }
    }
}
