using System.Collections.Generic;
using System.Threading.Tasks;
using Hsking.Mobile.Api.Models;

namespace Hsking.Mobile.Api.Facade
{
    public interface IApiFacade
    {
        Task<List<Habit>> GetHabits();
        Task<Token> Auth(string phoneNumber,string password);
        Task<object> Register(string phone);
        Task<object> Recover(string phone);
    }
}