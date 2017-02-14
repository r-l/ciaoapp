using System.Threading.Tasks;

namespace CiaoApp.Web.Services.Messaging
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
