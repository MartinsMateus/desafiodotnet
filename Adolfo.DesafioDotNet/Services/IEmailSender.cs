using System.Threading.Tasks;

namespace Adolfo.DesafioDotNet.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
