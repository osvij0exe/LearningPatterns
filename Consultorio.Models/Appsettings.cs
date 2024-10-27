using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Models
{
    public class Appsettings
    {
        public Jwt Jwt { get; set; } = default!;
        public SmtpConfiguration SmtpConfiguration { get; set; } = default!;
    }

    public class Jwt
    {
        public string SecretKey { get; set; } = default!;
        public string Audiencia { get; set; } = default!;
        public string Emisor { get; set; } = default!;
    }

    // para modificar como se enviaran los correos electronicos
    public class SmtpConfiguration
    {
        public string Server { get; set; } = default!;
        public string FromName { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
    }

}
