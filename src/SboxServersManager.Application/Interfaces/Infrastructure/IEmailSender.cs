using SboxServersManager.Infrastructure.EmailService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Application.Interfaces.Infrastructure
{
    public interface IEmailSender
    {
        Task SendEmail(Message message);
    }
}
