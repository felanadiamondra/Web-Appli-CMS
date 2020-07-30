using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace WebCMSJIR.Models.connexion
{
    public class login
    {
        OracleDataReader reader;
        public int Sp_Login(string login, string mdp, string GROUPE)
        {
            DBConnect b = new DBConnect();
            OracleConnection connection = b.GetConnection();
            connection.Open();
            OracleTransaction trans = connection.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT COUNT(1) FROM UTILISATEUR  WHERE LOGIN='" + login + "'  AND PASSWORD = '" + mdp + "' AND GROUPE= '" + GROUPE + "'",
                Connection = connection,
                CommandType = CommandType.Text
            };
            try
            {
                // Exécution de la requête     
                reader = cmd.ExecuteReader();
                // On soumet la requête au serveur: tout s'est bien déroulé , la requête est exécutée    
                trans.Commit();
            }
            catch (Exception ex)
            {
                // Une erreur est survenue: on ne valide pas la requête     
                trans.Rollback();
                Console.WriteLine("<body><script >alert('Requête non effectuée !!\nErreur: '" + ex.Message + "'');</script></body>");
            }
            finally
            {     // Libération des ressources     
                cmd.Dispose();
            }
            reader.Read();
            Int32 nb = reader.GetInt32(0);
            connection.Close();
            return nb;

        }

        public int Config_Login(string identifiant, string mdp)
        {
            DBConnect b = new DBConnect();
            OracleConnection connection = b.GetConnection();
            connection.Open();
            OracleTransaction trans = connection.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT COUNT(1) FROM UTILISATEUR  WHERE IDENTIFIANT='" + identifiant + "'  AND PASSWORD = '" + mdp + "' AND GROUPE= 'Administrateur'",
                Connection = connection,
                CommandType = CommandType.Text
            };
            try
            {
                // Exécution de la requête     
                reader = cmd.ExecuteReader();
                // On soumet la requête au serveur: tout s'est bien déroulé , la requête est exécutée    
                trans.Commit();
            }
            catch (Exception ex)
            {
                // Une erreur est survenue: on ne valide pas la requête     
                trans.Rollback();
                Console.WriteLine("<body><script >alert('Requête non effectuée !!\nErreur: '" + ex.Message + "'');</script></body>");
            }
            finally
            {     // Libération des ressources     
                cmd.Dispose();
            }
            reader.Read();
            Int32 nb = reader.GetInt32(0);
            connection.Close();
            return nb;
        }
    }
}
