using System;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCMSJIR.Views.Infirmerie
{
    public class FonctionInf
    {
        OracleDataReader dr;

        //Affiche fréquentation table
        public OracleDataReader AfficheFreq()
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();

            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT F.FREQMALA, F.NUMERO, F.NOM, F.AGE, F.SEXE, F.IDENTIFIANT, P.CODE_PREST FROM FREQMALA_JDE F, PRESTAT P WHERE F.HACMS IS NULL AND (TO_DATE(F.DFREQ, 'DD/MM/YYYY') = TO_DATE(SYSDATE, 'DD/MM/YYYY')) AND P.CODE_PREST = F.CODE_PREST ORDER BY F.NUMERO ASC",
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

        //Affiche fréquentation en atente chez les Médecins table 
        public OracleDataReader ListeFreqAttente()
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();

            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT F.FREQMALA, F.NUMERO, F.NOM, F.AGE, F.SEXE, F.IDENTIFIANT, P.CODE_PREST FROM FREQMALA_JDE F, PRESTAT P WHERE F.HACMS IS NOT NULL AND F.HAMEDE IS NULL AND (TO_DATE(F.DFREQ, 'DD/MM/YYYY') = TO_DATE(SYSDATE, 'DD/MM/YYYY')) AND P.CODE_PREST = F.CODE_PREST ORDER BY F.NUMERO ASC",
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
