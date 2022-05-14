using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IEmailSenderService
    {
        Task SendResetPasswordEmail(string email, string userName, string token);
    }
}
