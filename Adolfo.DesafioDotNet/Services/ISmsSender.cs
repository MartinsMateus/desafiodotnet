using System.Threading.Tasks;

namespace Adolfo.DesafioDotNet.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
