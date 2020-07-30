using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCMSJIR.Views.Medecin
{
    public class FonctionMed
    {
        OracleDataReader dr;
        string id = null;
        int nbr = 0;

        //Liste des fréquentations table
        public OracleDataReader GetFreqMed(string login)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();

            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT NUMERO ,NOM , AGE , CODE_PREST , NAT_CONSULT ,TEMP  , TAMAX ,TAMIN , PULLS ,POIDS , PC , ALBUM , GLICEMIE FROM FREQMALA_JDE WHERE IDENTIFIANT = '" + getIdent(login) + "'  AND (TO_DATE(DFREQ, 'DD/MM/YYYY') = TO_DATE(SYSDATE, 'DD/MM/YYYY')) AND HACMS IS NOT NULL AND HAMEDE IS NULL ORDER BY NUMERO ASC",
                Connection = conn,
                CommandType = CommandType.Text
            };
            try
            {
                // Exécution de la requête     
                dr = cmd.ExecuteReader();
                // On soumet la requête au serveur: tout s'est bien déroulé , la requête est exécutée    
                trans.Commit();
            }
            catch (Exception ex)
            {
                // Une erreur est survenue: on ne valide pas la requête     
                trans.Rollback();
                Console.WriteLine("<body><script >alert('Requête non effectuée !!\nErreur: '" + ex.Message + "'');</script></body>");
            }

            return dr;
        }

        //Avoir l'ID du Medecin
        public string getIdent(string login)
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

        public string getLogin(string log)
        {
            return log;
        }

        //Verifie l'existence du Medecin
        public int Comptlog(string log)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT COUNT(LOGIN) FROM UTILISATEUR WHERE LOGIN = '" + log + "'",
                Connection = conn,
                CommandType = CommandType.Text
            };
            conn.Open();
            // Exécution de la requête     
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                nbr = reader.GetInt16(0);
            }
            cmd.Dispose();
            return nbr;
        }

        //Affiche les fréquentations traitées du Medecin
        public OracleDataReader ListeFreqT(string login)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();

            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT F.FREQMALA, F.NUMERO, F.NOM, F.AGE, P.CODE_PREST, F.DATE_RENDEZ_VOUS, F.AVIS_MEDE, F.JREPOS FROM FREQMALA_JDE F, PRESTAT P WHERE F.HAMEDE IS NOT NULL AND (TO_DATE(F.DFREQ, 'DD/MM/YYYY') = TO_DATE(SYSDATE, 'DD/MM/YYYY')) AND P.CODE_PREST = F.CODE_PREST AND IDENTIFIANT = '" + getIdent(login) + "' ORDER BY F.NUMERO DESC",
                Connection = conn,
                CommandType = CommandType.Text
            };
            try
            {
                // Exécution de la requête     
                dr = cmd.ExecuteReader();
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
            return dr;
        }
    }
}
