using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CertGenerator
{
    //for_review
    public class CertificateConfiguration
    {
        //Info for certificate
        public X509Certificate2? RootCertificate { get; set; }

        public int CertLifeTime { get; set; }

        public string? CertName { get; set; }

        public string? Password { get; set; }

        public string? OutFolder { get; set; }
        public string? Email { get; set; }
    }
}
