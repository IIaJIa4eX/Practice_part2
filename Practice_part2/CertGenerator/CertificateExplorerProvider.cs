using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using Org.BouncyCastle.Operators;

namespace CertGenerator
{

    //for_review
    public class CertificateExplorerProvider
    {
        private string[] certificateStores = new string[] { "LocalMachine.My", "CurrentUser.My", "LocalMachine.Root", "CurrentUser.Root" };
        private List<X509Certificate2Wrapper> certificateList;
        private const string Current_User_My = "Текущий пользователь - Личные";
        private const string Local_Machine_My = "Локальный компьютер - Личные";
        private const string Local_Machine_Root = "Локальный компьютер - Доверенные корневые центры сертификации";
        private const string Current_User_Root = "Текущий пользователь - Доверенные корневы центры сертификации";
        private bool _privateKey;

        public CertificateExplorerProvider(bool privateKey)
        {
            _privateKey = privateKey;
        }



        public List<X509Certificate2Wrapper> Certificates
        {
            get
            {
                return certificateList;
            }
        }


        public void LoadCertificates()
        {
            certificateList = new List<X509Certificate2Wrapper>();

            foreach (string store in certificateStores)
            {
                certificateList.AddRange(LoadStore(store));
            }
        }


        private List<X509Certificate2Wrapper> LoadStore(string storeName)
        {   //обраение к хранилищу сертификатов
            X509Store x509store = new X509Store(ExtractStoreName(storeName), ExtractStoreLocation(storeName));
            x509store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
            try
            {
                return CertificatesToView(x509store.Certificates, storeName);
            }
            finally
            {
                x509store.Close();
            }
        }


        private List<X509Certificate2Wrapper> CertificatesToView(X509Certificate2Collection certificate2Collection, string groupName)
        {
            List<X509Certificate2Wrapper> certificate2List = new List<X509Certificate2Wrapper>();
            foreach (X509Certificate2 certificate in certificate2Collection)
            {
                string groupDesc = null;
                switch (groupName)
                {
                    case "CurrentUser.My":
                        groupDesc = Current_User_My;
                        break;
                    case "LocalMachine.My":
                        groupDesc = Local_Machine_My;
                        break;
                    case "LocalMachine.Root":
                        groupDesc = Local_Machine_Root;
                        break;
                    case "CurrentUser.Root":
                        groupDesc = Current_User_Root;
                        break;
                }

                if (_privateKey)
                {
                    if (certificate.HasPrivateKey)
                    {
                        certificate2List.Add(new X509Certificate2Wrapper(certificate, groupName, groupDesc));

                    }
                }
                else
                {
                    certificate2List.Add(new X509Certificate2Wrapper(certificate, groupName, groupDesc));
                }
            }

            return certificate2List;
        }


        public static StoreName ExtractStoreName(string store)
        {
            return (StoreName)Enum.Parse(typeof(StoreName), store.Substring(store.IndexOf('.') + 1));
        }


        public static StoreLocation ExtractStoreLocation(string store)
        {
            return (StoreLocation)Enum.Parse(typeof(StoreLocation), store.Substring(0, store.IndexOf('.')));
        }
    }
}
