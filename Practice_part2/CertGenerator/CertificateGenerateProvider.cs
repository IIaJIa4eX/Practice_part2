using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.X509.Extension;
using Org.BouncyCastle.X509;
using System.Collections;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Asn1.Pkcs;
using System.Security.Cryptography;

namespace CertGenerator
{
    public class CertificateGenerateProvider
    {
        public void GenerateRootCertificate(CertificateConfiguration settings)
        {
            SecureRandom secRnd = new SecureRandom();
            RsaKeyPairGenerator keyGen  = new RsaKeyPairGenerator();
            RsaKeyGenerationParameters param = new RsaKeyGenerationParameters
                (
                new Org.BouncyCastle.Math.BigInteger("10001", 16),
                new SecureRandom(),
                1024,
                25
                );
            keyGen.Init(param);
            AsymmetricCipherKeyPair keyPair = keyGen.GenerateKeyPair();

            string issuer = "CN=" + settings.CertName;

            string p12File = settings.OutFolder + @"/" + settings.CertName + ".p12";
            string crtFile = settings.OutFolder + @"/" + settings.CertName + ".crt";

            byte[] serialNumber = Guid.NewGuid().ToByteArray();
            serialNumber[0] = (byte)(serialNumber[0] & 0x7F);

            X509V3CertificateGenerator certGen = new X509V3CertificateGenerator();
            certGen.SetSerialNumber(new Org.BouncyCastle.Math.BigInteger(1, serialNumber));
            certGen.SetIssuerDN(new X509Name(issuer));
            certGen.SetNotBefore(DateTime.Now.ToUniversalTime());
            certGen.SetNotAfter(DateTime.Now.ToUniversalTime() + new TimeSpan(settings.CertLifeTime * 365, 0, 0, 0));
            certGen.SetSubjectDN(new X509Name(issuer));
            certGen.SetPublicKey(keyPair.Public);
            certGen.SetSignatureAlgorithm("MD5WITHRSA");
            certGen.AddExtension(X509Extensions.AuthorityKeyIdentifier, false, new AuthorityKeyIdentifierStructure(keyPair.Public));
            certGen.AddExtension(X509Extensions.SubjectKeyIdentifier, false, new SubjectKeyIdentifierStructure(keyPair.Public));
            certGen.AddExtension(X509Extensions.BasicConstraints, false, new BasicConstraints(true));

            X509Certificate rootCert = certGen.Generate(keyPair.Private);

            byte[] rawCert = rootCert.GetEncoded();

            try
            {
                using (FileStream fs = new FileStream(p12File, FileMode.CreateNew))
                {
                    Pkcs12Store p12 = new Pkcs12Store();
                    X509CertificateEntry certEntry = new X509CertificateEntry(rootCert);
                    p12.SetKeyEntry(settings.CertName, new AsymmetricKeyEntry(keyPair.Private),
                        new X509CertificateEntry[] { certEntry });
                    p12.Save(fs, settings.Password.ToCharArray(), secRnd);
                }
            }
            catch (Exception a)
            {
                throw new Exception($"При сохранении закрытой части произошла ошибка: {a.Message}");
            }


            try
            {
                using (FileStream fs = new FileStream(crtFile, FileMode.CreateNew))
                {
                    fs.Write(rawCert, 0, rawCert.Length);
                    return;
                }
            }
            catch (Exception a)
            {
                throw new Exception($"При сохранении открытой части произошла ошибка: {a.Message}");
            }
        }


        public void GenerateCertificate(CertificateConfiguration settings)
        {
            Org.BouncyCastle.X509.X509Certificate rootCertificateInternal = DotNetUtilities.FromX509Certificate(settings.RootCertificate);

            //key pair
            SecureRandom secRnd = new();
            RsaKeyPairGenerator keyGen = new();
            RsaKeyGenerationParameters param = new RsaKeyGenerationParameters(new Org.BouncyCastle.Math.BigInteger("10001", 16), new SecureRandom(), 1024, 25);
            keyGen.Init(param);
            AsymmetricCipherKeyPair keyPair = keyGen.GenerateKeyPair();

            string subject = "CN=" + settings.CertName;

            string p12File = settings.OutFolder + @"/" + settings.CertName + ".p12";
            string crtFile = settings.OutFolder + @"/" + settings.CertName + ".crt";

            //cert serial number
            byte[] serialNumber = Guid.NewGuid().ToByteArray();
            serialNumber[0] = (byte)(serialNumber[0] & 0x7F);

            //certificate settings
            X509V3CertificateGenerator certGen = new X509V3CertificateGenerator();
            certGen.SetSerialNumber(new Org.BouncyCastle.Math.BigInteger(1, serialNumber));
            certGen.SetIssuerDN(rootCertificateInternal.IssuerDN);
            certGen.SetNotBefore(DateTime.Now.ToUniversalTime());
            certGen.SetNotAfter(DateTime.Now.AddDays(100));
            certGen.SetSubjectDN(new Org.BouncyCastle.Asn1.X509.X509Name(subject));
            certGen.SetPublicKey(keyPair.Public);
            certGen.SetSignatureAlgorithm("MD5WITHRSA");
            certGen.AddExtension(X509Extensions.AuthorityKeyIdentifier, false, new AuthorityKeyIdentifierStructure(rootCertificateInternal.GetPublicKey()));
            certGen.AddExtension(X509Extensions.SubjectKeyIdentifier, false, new SubjectKeyIdentifierStructure(keyPair.Public));
            KeyUsage keyUsage = new KeyUsage(settings.CertName.EndsWith("CA") ? 182 : 176);
            certGen.AddExtension(X509Extensions.KeyUsage, true, keyUsage);
            ArrayList keyPruposes = new();
            //keyPruposes.Add(KeyPurposeID.IdKPServerAuth); //server
            keyPruposes.Add(KeyPurposeID.IdKPCodeSigning); //code sign
            //keyPruposes.Add(KeyPurposeID.IdKPEmailProtection);  //email
            certGen.AddExtension(X509Extensions.ExtendedKeyUsage, true, new ExtendedKeyUsage(keyPruposes));
            if (settings.CertName.EndsWith("CA"))
                certGen.AddExtension(X509Extensions.BasicConstraints, true, new BasicConstraints(true));

            
            FieldInfo fieldInfo = typeof(X509V3CertificateGenerator).GetField("tbsGen", BindingFlags.NonPublic | BindingFlags.Instance);
            V3TbsCertificateGenerator v3TbsCertificate = (V3TbsCertificateGenerator)fieldInfo.GetValue(certGen);
            TbsCertificateStructure tbsCertificate = v3TbsCertificate.GenerateTbsCertificate();

            
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] tbsCertificateHash = md5.ComputeHash(tbsCertificate.GetDerEncoded());

            
            RSAPKCS1SignatureFormatter signatureFormatter = new();
            signatureFormatter.SetHashAlgorithm("MD5");
            signatureFormatter.SetKey(settings.RootCertificate.PrivateKey);
            byte[] certificateSign = signatureFormatter.CreateSignature(tbsCertificateHash);

            
            X509Certificate signCertificate = new X509Certificate(
                new X509CertificateStructure(
                    tbsCertificate,
                    new AlgorithmIdentifier(
                        PkcsObjectIdentifiers.MD5WithRsaEncryption),
                    new Org.BouncyCastle.Asn1.DerBitString(certificateSign)));

            
            try
            {
                using (FileStream fs = new FileStream(p12File, FileMode.CreateNew))
                {
                    Pkcs12Store p12 = new();
                    X509CertificateEntry certificateEntry = new(signCertificate);
                    X509CertificateEntry rootCertificateEntry = new(rootCertificateInternal);
                    p12.SetKeyEntry(settings.CertName, new AsymmetricKeyEntry(keyPair.Private), new X509CertificateEntry[] { certificateEntry, rootCertificateEntry });
                    p12.Save(fs, settings.Password.ToCharArray(), secRnd);
                }
            }
            catch (Exception a)
            {
                throw new Exception($"Что-то пошло не так во время создания: {a.Message}");
            }


            return;
        }
    }
}
