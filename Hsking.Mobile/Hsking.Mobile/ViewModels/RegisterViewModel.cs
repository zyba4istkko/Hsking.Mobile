using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using Hsking.Mobile.Api;
using Hsking.Mobile.Api.Facade;
using Hsking.Mobile.ViewModels.Base;

namespace Hsking.Mobile.ViewModels
{
    public class RegisterViewModel : LoadingScreen
    {
        private readonly IApiFacade _apiFacade;
        private readonly IApiSettings _apiSettings;
        private string _phone;
        private int _currentStep = 1;
        private MvxCommand _authCommand;
        private MvxCommand _registerUserAndWaitSmsCommand;

        public ICommand RegisterUserAndWaitSmsCommand
        {
            get
            {
                _registerUserAndWaitSmsCommand = _registerUserAndWaitSmsCommand ?? new MvxCommand(RegisterUserAndWaitSms);
                return _registerUserAndWaitSmsCommand;
            }
        }
        public ICommand AuthCommand
        {
            get
            {
                _authCommand = _authCommand ?? new MvxCommand(DoAuth);
                return _authCommand;
            }
        }

        private string _code;

        public string Code
        {
            get { return _code; }
            set
            {
                _code = value;
                RaisePropertyChanged(() => Code);
                RaisePropertyChanged(() => CanAuth);
            }
        }

        

        private async void DoAuth()
        {
            base.Wait(true,"Входим..");
            RaisePropertyChanged(() => CanAuth);
            RaisePropertyChanged(() => CanRegister);
            try
            {
                var token = await _apiFacade.Auth("+" + Phone, Code);
                ShowViewModel<MainViewModel>();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                base.Wait(false);
                RaisePropertyChanged(() => CanAuth);
                RaisePropertyChanged(() => CanRegister);
            }
            
        }


        public bool CanRegister
        {
            get
            {
                return !String.IsNullOrEmpty(Phone) && Phone.Length == 11 && !base.IsLoading;
            }
            
        }

        public bool CanAuth
        {
            get { return !String.IsNullOrEmpty(Code) && Code.Length>=4 && !base.IsLoading; }

        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                RaisePropertyChanged(()=>CanRegister);
                RaisePropertyChanged(() => Phone);
            }
        }

        public int CurrentStep
        {
            get { return _currentStep; }
            set
            {
                _currentStep = value;
                RaisePropertyChanged(() => CurrentStep);
            }
        }

        

        

        public RegisterViewModel(IApiFacade apiFacade,IApiSettings apiSettings)
        {
            _apiFacade = apiFacade;
            _apiSettings = apiSettings;
        }

        private async void RegisterUserAndWaitSms()
        {
            base.Wait(true,"Регистрируемся..");
            RaisePropertyChanged(() => CanAuth);
            RaisePropertyChanged(() => CanRegister);
            try
            {
                var result = await _apiFacade.Register("+"+Phone);
                CurrentStep = 2;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                base.Wait(false);
                RaisePropertyChanged(() => CanAuth);
                RaisePropertyChanged(() => CanRegister);
            }
        
         
        }

        


       




    }
}
