using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hsking.Mobile.Api
{
    public class ApiException:Exception
    {
        public int ErrorCode { get; set; }

        public ApiException(int code,string message)
            :base(message)
        {
            ErrorCode = code;
        }
    }
}
