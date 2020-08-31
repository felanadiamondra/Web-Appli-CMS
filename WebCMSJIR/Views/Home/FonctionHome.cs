using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.Text;
using System.IO;
using WebCMSJIR;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace WebCMSJIR.Views.Home
{
    public class FonctionHome
    {
        string id = null;
        public string GetID(string login)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT IDENTIFIANT FROM UTILISATEUR WHERE LOGIN = '" + login + "'",
                Connection = conn,
                CommandType = CommandType.Text
            };
            conn.Open();
            // Exécution de la requête     
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                id = reader.GetString(0);
            }
            cmd.Dispose();
            return id;
        }



        public string GetStatut(string login)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT STATUT FROM UTILISATEUR WHERE IDENTIFIANT = '" + GetID(login) + "'",
                Connection = conn,
                CommandType = CommandType.Text
            };
            OracleDataReader dr = cmd.ExecuteReader();
            dr.Read();
            string compt = dr.GetString(0);
            cmd.Dispose();
            return compt;
        }

        public string getLogin (string login)
        {
            return login;
        }
    }
}


