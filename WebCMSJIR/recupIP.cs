using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCMSJIR
{
    public class recupIP
    {
        String codecms;
        String site;
        String codemag;
        String sa;

        public string recupcodecms(string adresseip)
        {
            if(adresseip == "192.168.160")
            {
                codecms = "CMSTANA";
            }

            else if (adresseip == "172.19.118")
            {
                codecms = "CMSTANA";
            }

            else if (adresseip == "192.168.44")
            {
                codecms = "CMSABE";
            }
            return codecms;
        }

        public string recupsite(string adresseip)
        {
            if (adresseip == "172.19.118")
            {
                site = "100";
            }
            else if(adresseip == "192.168.160")
            {
                site = "100";
            }
            else if (adresseip == "192.168.44")
            {
                site = "104";
            }
            return site;

        }

        public string recupmag(string adresseip)
        {
            if (adresseip == "172.19.118")
            {
                codemag = "A01X";
            }
            else if(adresseip == "192.168.160")
            {
                codemag = "A01X";
            }
            else if (adresseip == "192.168.44")
            {
                codemag = "A048";
            }
            return codemag;
        }

        public string recupsa(string adresseip)
        {
            if (adresseip == "172.19.118")
            {
                sa = "10012529";
            }
            else if (adresseip == "92.168.160")
            {
                sa = "10012529";
            }
            else if (adresseip == "192.168.44")
            {
                sa = "11005878";
            }
            return sa;
        }
    }
}
