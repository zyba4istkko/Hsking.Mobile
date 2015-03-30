using System;
using System.Collections.Generic;
using System.Text;
using Hsking.Mobile.Api;
using Hsking.Mobile.Api.Models;

namespace Hsking.Mobile.Settings
{
    public class ApiSettings:IApiSettings
    {
        private Token _token;

        public string BaseUrl
        {
            get { return "http://hskingapi.azurewebsites.net/api"; }
        }

        public Api.Models.Token SavedToken
        {
            get { return _token; }
            set { _token = value; }
        }
    }
}
