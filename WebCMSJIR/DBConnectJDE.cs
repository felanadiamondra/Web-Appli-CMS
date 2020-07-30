using Oracle.ManagedDataAccess.Client;
using System;

namespace WebCMSJIR
{
    public class DBConnectJDE
    {
        string data_connex;
        public DBConnectJDE()
        {
            try
            {
                //    data_connex = "Data Source=(DESCRIPTION =" +
                //  "(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1522))" +
                //  "(CONNECT_DATA =" +
                //  "(SERVER = DEDICATED)" +
                //  "(SERVICE_NAME = orcl)" +
                //  ")" +
                //" );USer ID=stageL2;password=stageL2";

                data_connex = "Data Source=(DESCRIPTION =" +
               " (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = 172.16.205.10)(PORT = 1521)))" +
               "(CONNECT_DATA =" +
               "(SERVICE_NAME = jdedb)" +
               " )" +
               " );User ID=TESTDTA;password=TESTDTA";
            }
            catch (Exception)
            {
                Console.WriteLine("<body>< script > alert('Erreur de connexion');</script></body>");
            }
        }
        public DBConnectJDE(string data_connex)
        {
            this.data_connex = data_connex;
        }

        public OracleConnection GetConnectionJDE()
        {
            OracleConnection connexion = new OracleConnection(data_connex);
            return connexion;
        }
    }
}

