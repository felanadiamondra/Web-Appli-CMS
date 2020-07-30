using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace WebCMSJIR.Views.Utilisateur
{
    public class FonctionUser
    {
        OracleDataReader dr;
        //Afficher Utilisateurs table
        public OracleDataReader AfficheUser()
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT IDENTIFIANT, NOM , GROUPE , LOGIN , PASSWORD , CODE_PREST, TO_CHAR(DATE_SAI ,'DD/MM/YYYY') , STATUT  FROM UTILISATEUR ORDER BY TO_CHAR(DATE_SAI ,'DD/MM/YYYY') DESC",
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

        //Vérifie l'existence de l'Utilisateur
        public int CompterUser(string ID)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            Int32 nb = 0;
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT COUNT(IDENTIFIANT) FROM UTILISATEUR WHERE IDENTIFIANT= '" + ID + "'",
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

        //Vérifie l'existance du Login
        public int CompterLogin(string login)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            Int32 nb = 0;
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT COUNT(LOGIN) as nb FROM UTILISATEUR WHERE LOGIN= '" + login + "'",
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

        //Affiche Utilisateurs à modifier avec ajax 
        public OracleDataReader AfficherUser(string identifiant)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT IDENTIFIANT, NOM, GROUPE , CODE_PREST , LOGIN, PASSWORD, STATUT FROM UTILISATEUR WHERE IDENTIFIANT= '" + identifiant + "'",
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

        //Vérifie mot de passe
        public int ComptMdp(string Amdp, string ID)
        {
            int compt = 0;
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT COUNT(1) FROM UTILISATEUR WHERE PASSWORD ='" + Amdp + "' AND IDENTIFIANT ='" + ID + "'",
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
            compt = dr.GetInt32(0);
            return compt;
        }

        public OracleDataReader getPrestation(string code_act)
        {

            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT CODE_PREST,LIB_PREST FROM PRESTAT WHERE CODE_ACT = '" + code_act + "' ORDER BY LIB_PREST ASC ",
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



