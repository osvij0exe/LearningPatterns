using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Services.Interfaces
{
    public interface IEmailServices
    {

        Task SendEmailAsync(string email,string subject,string message);

    }
}
