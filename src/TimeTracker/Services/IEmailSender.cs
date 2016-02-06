using System.Threading.Tasks;

namespace Preduzece.TimeTracker.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
