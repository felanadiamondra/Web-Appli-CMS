using Oracle.ManagedDataAccess.Client;
using System;

namespace WebCMSJIR
{
    public class DBConnect
    {
        String data_path;
        public DBConnect()
        {
            try
            {
                // data_path = "Data Source=(DESCRIPTION =" +
                //"(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1522))" +
                //"(CONNECT_DATA =" +
                //"(SERVER = DEDICATED)" +
                //"(SERVICE_NAME = orcl)" +
                //")" +
                //" );USer ID=stageL2;password=stageL2";

                data_path = "Data Source=(DESCRIPTION =" +
                "(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.222.92)(PORT = 1521)))" +
                "(CONNECT_DATA =" +
                " (SERVICE_NAME = oracomm)" +
                " )" +
                " );User ID=stagecms;password=stagecms";
            }
            catch (Exception)
            {
                Console.WriteLine("Erreur de connexion");
            }
        }

        public DBConnect(string data_path)
        {
            this.data_path = data_path;

        }
        public OracleConnection GetConnection()
        {
            OracleConnection connexion = new OracleConnection(data_path);
            return connexion;
        }

    }
}

