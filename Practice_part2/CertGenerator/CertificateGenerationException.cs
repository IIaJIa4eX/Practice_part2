using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertGenerator
{
    public class CertificateGenerationException : Exception
    {
        //for_review
        public CertificateGenerationException(string message) : base(message)
        {

        }
    }
}
