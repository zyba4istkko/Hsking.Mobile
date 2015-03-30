using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Hsking.Mobile.Api.Models;
using Hsking.Mobile.Api.Requests;
using Hsking.Mobile.Api.Requests.Base;
using Newtonsoft.Json;
using RestSharp.Portable;
using RestSharp.Portable.Authenticators;
using RestSharp.Portable.Deserializers;

namespace Hsking.Mobile.Api.Executer
{
    public class ApiExecuter : IApiExecuter
    {
        private RestClient _restClient;

        public ApiExecuter(IApiSettings apiSettings)
        {
            _restClient = new RestSharp.Portable.RestClient(apiSettings.BaseUrl);
            _restClient.AddHandler("application/json", new JsonDeserializer());
       
        }
        public async Task<T> Execute<T>(IRequest request)
        {
            var restRequest = CreateRequest(request);
            var uri=_restClient.BuildUri(restRequest);
            try
            {
                if (request is AuthRequest)
                {
                    var response = await _restClient.Execute<T>(restRequest);
                    return response.Data;
                }
                else
                {
                    var response = await _restClient.Execute<ApiResponse<T>>(restRequest);
                    var data = response.Data;
                    if (data.ErrorCode == 0)
                    {
                        return data.Result;
                    }
                    else
                    {
                        throw new ApiException(data.ErrorCode, data.ErrorMessage);
                    }
                }
             
            }
            catch (Exception e)
            {
                throw new ApiException(10000, e.Message);
            }
        
         
        }

        private RestRequest CreateRequest(IRequest request)
        {
            if (request is AuthRequest)
            {
                //хук для oauth там не json
                return CreateAuthRequest(request);
            }
            var restRequest = CreateAndPrepareByUrl(request);
            restRequest.Parameters.Clear();
            restRequest.AddHeader("Accept", "application/json");
            if (request.Token != null) { restRequest.AddHeader("Authorization", String.Format("{0} {1}", "Bearer", request.Token.Value)); }
            if (request.Params!=null && request.Params.Any())
            {
                restRequest.AddBody(request.Params);
            }
            return restRequest;
        }

        private RestRequest CreateAuthRequest(IRequest request)
        {
            var restRequest = CreateAndPrepareByUrl(request);
            foreach (var par in request.Params)
            {
                restRequest.AddParameter(par.Key, par.Value);
            }
            return restRequest;
        }

        private  RestRequest CreateAndPrepareByUrl(IRequest request)
        {
            var url = String.IsNullOrEmpty(request.Controller)
                ? request.MethodName
                : String.Format("{0}/{1}", request.Controller, request.MethodName);

            var restRequest = new RestRequest(url, HttpMethod.Post);
            return restRequest;
        }
      
    }
}
