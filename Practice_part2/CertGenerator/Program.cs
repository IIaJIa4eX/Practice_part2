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
            CertificateGenerateProvider certGenerator = new CertificateGenerateProvider();
            certGenerator.GenerateRootCertificate(certificationConfiguration);
            Thread.Sleep(1);
        }
    }
}