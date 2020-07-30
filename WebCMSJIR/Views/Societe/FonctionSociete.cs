using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace WebCMSJIR.Views.Societe
{
    public class FonctionSociete
    {
        OracleDataReader dr;

        //Affiche Société table
        public OracleDataReader AfficheSociete()
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT CODE_STE, LIBELLE, TYPE_CLI, ADRESSE1 ,TO_CHAR(DATE_SAI ,'DD/MM/YYYY HH24:MI:SS') FROM STE",
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

        //Affiche Société avec Ajax (Modifier)
        public OracleDataReader GetSte(string code)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT CODE_STE, LIBELLE, TYPE_CLI, ADRESSE1, TO_DATE(DATE_SAI ,'DD/MM/YYYY HH24:MI:SS') FROM STE WHERE CODE_STE='" + code + "'",
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

        //Verifie l'existence de la Société
        public int CompterSte(string code)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            Int32 nb = 0;
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT COUNT(CODE_STE) FROM STE WHERE CODE_STE= '" + code + "'",
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
            dr.Read();
            nb = dr.GetInt32(0);
            return nb;
        }
    }
}
