using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hsking.Mobile.Api.Models;

namespace Hsking.Mobile.Api
{
    public interface IApiSettings
    {
        string BaseUrl { get; }
        Token SavedToken { get; set; }


     
    }
}
