using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;


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
            //Mvx.RegisterSingleton(typeof(ISettingsService), _settingsService);
            //Mvx.RegisterType<IRequestExecuterService, RequestExecuterService>();
            //Mvx.ConstructAndRegisterSingleton<IApiManager, ApiManager>();
        }
		
	}
}
