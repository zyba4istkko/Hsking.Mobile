using System.Collections.Generic;
using Hsking.Mobile.Api.Requests.Base;

namespace Hsking.Mobile.Api.Requests
{
    public class GetHabitsRequest:IRequest
    {
        public string Controller
        {
            get { return "Habits"; }
            
        }
        public string MethodName
        {
            get { return "GetHabits"; }
        }

        public Dictionary<string, string> Params
        {
            get { return null; }
        }

        public Models.Token Token { get; set; }
    }
}
