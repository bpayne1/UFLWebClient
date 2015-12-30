using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UFLWebClient
{
    class Program
    {
        static string uri = "https://server:port/connectordata/Webservice"; //Address from UFL Connector Datasource configuration

        static void Main(string[] args)
        {
            string data = "servicetest,72.00," + DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss");
            Console.WriteLine("Data to send: " + data);
            byte[] fileToSend = Encoding.UTF8.GetBytes(data);
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(
               (object sender, X509Certificate certification, X509Chain chain, SslPolicyErrors sslPolicyErrors) => { return true; });
            using (var wb = new WebClient())
            {
                var responsess = wb.UploadData(@uri, "PUT", fileToSend);
                string responses = Encoding.ASCII.GetString(responsess);
                Console.WriteLine(responses);
            }

            Console.ReadLine();
            Console.WriteLine("ReadLine");
        }
    }
}
