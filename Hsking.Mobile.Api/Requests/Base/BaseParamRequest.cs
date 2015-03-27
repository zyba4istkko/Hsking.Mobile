using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hsking.Mobile.Api.Requests.Base
{
    public abstract class BaseParamRequest:IRequest
    {
        private Dictionary<string, string> _params;

        public BaseParamRequest()
        {
            _params = new Dictionary<string, string>();
        }

        public void AddParam(string key, string value)
        {
            _params.Add(key,value);
        }

       public abstract string Controller { get; }
       public abstract  string MethodName { get; }

       public Dictionary<string, string> Params
       {
            get { return _params; }
       }


       public Models.Token Token { get; set; }
       
    }
}
