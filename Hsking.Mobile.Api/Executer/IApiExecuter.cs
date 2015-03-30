using System.Threading.Tasks;
using Hsking.Mobile.Api.Requests.Base;

namespace Hsking.Mobile.Api.Executer
{
    public interface IApiExecuter
    {
        Task<T> Execute<T>(IRequest request);
    }
}