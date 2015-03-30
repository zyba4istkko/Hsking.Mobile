using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Hsking.Mobile.Api.ExceptionRouter;
using Hsking.Mobile.Api.Executer;
using Hsking.Mobile.Api.Models;
using Hsking.Mobile.Api.Requests;
using Hsking.Mobile.Api.Requests.Base;

namespace Hsking.Mobile.Api.Facade
{
    public class ApiFacade : IApiFacade
    {
        private readonly IApiExceptionRouter _exceptionRouter;
        private IApiExecuter _apiExecuter;
        private readonly IApiSettings _apiSettings;
        

        public ApiFacade(IApiExecuter apiExecuter,IApiSettings apiSettings)
        {
            _apiExecuter = apiExecuter;
            _apiSettings = apiSettings;
   
        }

        public Task<List<Habit>> GetHabits()
        {
            return ExecuteWithErrorHandling<List<Habit>>(new GetHabitsRequest());
        }

        public async Task<Token> Auth(string phoneNumber,string password)
        {
            var authRequest = new AuthRequest();
            authRequest.AddParam("grant_type", "password");
            authRequest.AddParam("userName", phoneNumber);
            authRequest.AddParam("password", password);
            var token=await ExecuteWithErrorHandling<Token>(authRequest);
            _apiSettings.SavedToken = token;
            return token;
        }



        private Task<T> ExecuteWithErrorHandling<T>(IRequest request)
        {
            try
            {
                request.Token = _apiSettings.SavedToken;//Добавляем токен
               return _apiExecuter.Execute<T>(request);
            }
            catch (ApiException ex)
            {
             
               throw ex;
            }
        }


        public Task<object> Register(string phone)
        {
            var registerRequest = new RegisterRequest();
            registerRequest.AddParam("Phone",phone);
            return ExecuteWithErrorHandling<object>(registerRequest);
        }

        public Task<object> Recover(string phone)
        {
            var recoverRequest = new RecoverRequest();
            recoverRequest.AddParam("Phone", phone);
            return ExecuteWithErrorHandling<object>(recoverRequest);
        }
    }
}
