using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace WebCMSJIR
{
    public class IP
    {
        public string adresseIp()

        {
            IPHostEntry host;
            string localIP = "?";
            string localIP2 = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                    int index = localIP.LastIndexOf('.');
                    localIP2 = localIP.Substring(0, index);
                    Console.WriteLine("Mon adresse IP est :" + localIP);
                    Console.WriteLine("Plage d'adresse  : " + localIP2);
                }
            }
            return localIP2;
        }
    }
}
