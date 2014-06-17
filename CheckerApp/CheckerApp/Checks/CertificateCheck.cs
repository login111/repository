using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace CheckerApp.Checks
{
    class CertificateCheck : ICheck
    {
        public CheckResult Check(int delay)
        {
            Thread.Sleep(1000 * delay);

            CheckResult result = new CheckResult();
            result.code = CheckResult.StatusCode.OK;
            result.checkName = "Certificate Check";
            result.message = "";

            try
            {

                Random rand = new Random();
                StoreName storeName = StoreName.Root;

                X509Store store = new X509Store(storeName, StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection certificates = store.Certificates;
                if (certificates.Count > 0)
                {
                    X509Certificate2 randCertificate = certificates[rand.Next(certificates.Count)];
                    DateTime expiredDate = DateTime.Parse(randCertificate.GetExpirationDateString());

                    if (expiredDate >= DateTime.Now)
                    {
                        result.code = CheckResult.StatusCode.OK;
                        result.message = "Certificate " + randCertificate.FriendlyName + " is not expired" + "\n"
                                         + "ExpirationDate : " + expiredDate.ToString();
                    }
                    else
                    {
                        result.code = CheckResult.StatusCode.ERROR;
                        result.message = "Certificate " + randCertificate.FriendlyName + " is expired" + "\n"
                                         + "ExpirationDate : " + expiredDate.ToString();
                    }
                }
                else
                {
                    result.code = CheckResult.StatusCode.OK;
                    result.message = "No certificates found in " + storeName.ToString();
                }

            }
            catch (Exception e)
            {
                result.code = CheckResult.StatusCode.ERROR;
                result.message = e.Message;            
            }

            return result;
            }

            
        }
    }

