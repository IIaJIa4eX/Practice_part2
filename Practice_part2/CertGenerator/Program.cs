namespace CertGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating root cert..");
            CertificateConfiguration certificationConfiguration = new CertificateConfiguration()
            {
                CertName = "Random company CA",
                Password = "12345678",
                CertLifeTime = 3,
                OutFolder = @"C:\testcert"
                
            };
            //CertificateGenerateProvider certGenerator = new CertificateGenerateProvider();
            //certGenerator.GenerateRootCertificate(certificationConfiguration);
            Thread.Sleep(1);
            //certies
            Console.WriteLine("/loading / Certies");
            int counter = 0;
            int certIndex = 0;
            CertificateExplorerProvider certificateExplorerProvider = new CertificateExplorerProvider(true);
            certificateExplorerProvider.LoadCertificates();
            foreach(var cert in certificateExplorerProvider.Certificates)
            {
                if(cert.PublishedFor == certificationConfiguration.CertName)
                {
                    certIndex = counter;
                }
                Console.WriteLine($"{counter++} >>> {cert}");


            }
            CertificateConfiguration certificationConfiguration2 = new CertificateConfiguration()
            {
                CertName = "RandomDepartment",
                RootCertificate = certificateExplorerProvider.Certificates[certIndex].Certificate,
                Password = "12345678",
                CertLifeTime = 3,
                OutFolder = @"C:\testcert"

            };
            CertificateGenerateProvider certGenerator2 = new CertificateGenerateProvider();
            certGenerator2.GenerateCertificate(certificationConfiguration2);
            Console.WriteLine("Done!");
        }
    }
}