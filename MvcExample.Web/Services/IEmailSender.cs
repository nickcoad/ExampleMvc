using System.Threading.Tasks;

namespace MvcExample.Web.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
