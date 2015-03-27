using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hsking.Mobile.Api.Models;

namespace Hsking.Mobile.Api.Requests.Base
{
    public interface IRequest
    {
        string Controller { get; }
        string MethodName { get; }

        Token Token { get; set; }
        Dictionary<string, string> Params { get; } 
    }
}
