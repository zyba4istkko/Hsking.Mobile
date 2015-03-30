using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hsking.Mobile.Api.Models;

namespace Hsking.Mobile.Api.Tests
{
    public class FakeApiSettings:IApiSettings
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
