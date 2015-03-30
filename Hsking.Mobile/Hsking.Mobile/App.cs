using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using Hsking.Mobile.Api;
using Hsking.Mobile.Api.Executer;
using Hsking.Mobile.Api.Facade;
using Hsking.Mobile.Settings;


namespace Hsking.Mobile
{
    public class App : MvxApplication
	{
		public App ()
		{
			
		}
        public override void Initialize()
        {
            //CreatableTypes()
            //    .EndingWith("Service")
            //    .AsInterfaces()
            //    .RegisterAsLazySingleton();

            RegisterAppStart<ViewModels.MainViewModel>();
            // _apiExecuter = new ApiExecuter("http://hskingapi.azurewebsites.net/api");
            Mvx.RegisterType<IApiSettings,ApiSettings>();
            Mvx.RegisterType<IApiExecuter,ApiExecuter>();
            Mvx.RegisterType<IApiFacade,ApiFacade>();
            //Mvx.RegisterType<IRequestExecuterService, RequestExecuterService>();
            //Mvx.ConstructAndRegisterSingleton<IApiManager, ApiManager>();
        }
		
	}
}
