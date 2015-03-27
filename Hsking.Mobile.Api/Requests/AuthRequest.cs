using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hsking.Mobile.Api.Requests.Base;

namespace Hsking.Mobile.Api.Requests
{
    public class AuthRequest:BaseParamRequest
    {
        
        public override string Controller
        {
            get { return ""; }
        }

        public override string MethodName
        {
            get { return "token"; }
        }

    }
}
