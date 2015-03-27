using System;
using System.Diagnostics;
using System.Linq;
using Hsking.Mobile.Api.ExceptionRouter;
using Hsking.Mobile.Api.Facade;

using NUnit.Framework;

namespace Hsking.Mobile.Api.Tests
{
    [TestFixture()]
    public class ApiServiceTest
    {
          [Test()]
        public async void GetHabits()
          {
              var facade = new ApiFacade(new ApiExceptionHandler());
              var result=await facade.GetHabits();
              Assert.IsTrue(result.Any());
          }
            [Test()]
        public async void Auth()
        {
            var facade = new ApiFacade(new ApiExceptionHandler());
            var result = await facade.Auth("+79166728879", "929672");
            Assert.IsNotNull(result);
        }
         [Test()]
        public async void Register()
        {
           var facade = new ApiFacade(new ApiExceptionHandler());
             try
             {
                 var result = await facade.Register("+79166728879");
             }
             catch (Exception e)
             {
                 Assert.AreEqual(e.Message, "User exist");
             }
        }
        [Test()]
         public async void Recover()
         {
             var facade = new ApiFacade(new ApiExceptionHandler());
             var result = await facade.Recover("+79166728879");
             Assert.IsNotNull(result);

         }


    }

    public class ApiExceptionHandler : IApiExceptionRouter
    {
        public void Route(ApiException exception)
        {
          Debug.Write(exception.Message);
        }
    }
}
