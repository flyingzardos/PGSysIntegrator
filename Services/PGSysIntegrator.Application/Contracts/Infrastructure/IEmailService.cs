using System.Threading.Tasks;
using PGSysIntegrator.Application.Models;

namespace PGSysIntegrator.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
