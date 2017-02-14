using System.Threading.Tasks;

namespace CiaoApp.Web.Services.Messaging
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
