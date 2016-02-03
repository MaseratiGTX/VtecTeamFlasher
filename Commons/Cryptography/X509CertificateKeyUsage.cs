using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using com.neoservice.neofiscal.Commons.Helpers.Objects;

namespace com.neoservice.neofiscal.Commons.Cryptography
{
    public class X509CertificateKeyUsage
    {
        public static X509CertificateKeyUsage None = new X509CertificateKeyUsage(X509KeyUsageFlags.None, "нет данных об использовании ключа");
        public static X509CertificateKeyUsage EncipherOnly = new X509CertificateKeyUsage(X509KeyUsageFlags.EncipherOnly, "только для шифрования");
        public static X509CertificateKeyUsage CrlSign = new X509CertificateKeyUsage(X509KeyUsageFlags.CrlSign, "подпись списка отзыва сертификатов");
        public static X509CertificateKeyUsage KeyCertSign = new X509CertificateKeyUsage(X509KeyUsageFlags.KeyCertSign, "подпись сертификатов");
        public static X509CertificateKeyUsage KeyAgreement = new X509CertificateKeyUsage(X509KeyUsageFlags.KeyAgreement, "проверка соответствия ключей");
        public static X509CertificateKeyUsage DataEncipherment = new X509CertificateKeyUsage(X509KeyUsageFlags.DataEncipherment, "шифрование данных");
        public static X509CertificateKeyUsage KeyEncipherment = new X509CertificateKeyUsage(X509KeyUsageFlags.KeyEncipherment, "шифрование ключей");
        public static X509CertificateKeyUsage NonRepudiation = new X509CertificateKeyUsage(X509KeyUsageFlags.NonRepudiation, "для аутентификации");
        public static X509CertificateKeyUsage DigitalSignature = new X509CertificateKeyUsage(X509KeyUsageFlags.DigitalSignature, "цифровая подпись");
        public static X509CertificateKeyUsage DecipherOnly = new X509CertificateKeyUsage(X509KeyUsageFlags.DecipherOnly, "только для расшифровки");

        
        public X509KeyUsageFlags KeyUsage { get; private set; }
        public string Description { get; private set; }
     
 
        public static Dictionary<X509KeyUsageFlags, X509CertificateKeyUsage> Map { get; private set; }



        private X509CertificateKeyUsage(X509KeyUsageFlags keyUsage, string description)
        {
            if (Map == null)
            {
                Map = new Dictionary<X509KeyUsageFlags, X509CertificateKeyUsage>();
            }


            KeyUsage = keyUsage;
            Description = description;

            Map[KeyUsage] = this;
        }


        public static X509KeyUsageFlags[] Parse(string keyUsages, string delimiter = "|")
        {
            if (keyUsages.IsEmpty())
            {
                return null;
            }


            var result = new List<X509KeyUsageFlags>();

            foreach (var keyUsage in keyUsages.Split(new []{delimiter}, StringSplitOptions.RemoveEmptyEntries))
            {
                X509KeyUsageFlags usageFlag;
                
                if (Enum.TryParse(keyUsage, out usageFlag))
                {
                    result.Add(usageFlag);
                }
            }


            return result.ToArray();
        }
    }
}