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
    public class ApiFacade
    {
        private readonly IApiExceptionRouter _exceptionRouter;
        private ApiExecuter _apiExecuter;
        private Token _token;

        public ApiFacade(IApiExceptionRouter exceptionRouter)
        {
            _exceptionRouter = exceptionRouter;
            _apiExecuter = new ApiExecuter("http://hskingapi.azurewebsites.net/api");
            //_apiExecuter = new ApiExecuter("http://localhost:17720/api");
        }

        public Task<List<Habit>> GetHabits()
        {
            return ExecuteWithErrorHandling<List<Habit>>(new GetHabitsRequest());
        }

        public Task<Token> Auth(string phoneNumber,string password)
        {
            var authRequest = new AuthRequest();
            authRequest.AddParam("grant_type", "password");
            authRequest.AddParam("userName", phoneNumber);
            authRequest.AddParam("password", password);
            return ExecuteWithErrorHandling<Token>(authRequest);
        }



        private Task<T> ExecuteWithErrorHandling<T>(IRequest request)
        {
            try
            {
               request.Token = _token;//Добавляем токен
               return _apiExecuter.Execute<T>(request);
            }
            catch (ApiException ex)
            {
               _exceptionRouter.Route(ex);
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
