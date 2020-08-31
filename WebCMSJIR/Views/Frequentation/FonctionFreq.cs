using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace WebCMSJIR.Views.Frequentation
{
    public class FonctionFreq
    {
        OracleDataReader dr;
        int nb = 0;

        //Attribue les ID de chaque fréquentation
        public int IDFreq()
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            Int32 nb = 0;

            OracleCommand req = new OracleCommand
            {
                CommandText = "SELECT COUNT(FREQMALA)+1  FROM FREQMALA_JDE ",
                Connection = conn,
                CommandType = CommandType.Text
            };
            try
            {
                // Exécution de la requête     
                dr = req.ExecuteReader();
                // On soumet la requête au serveur: tout s'est bien déroulé , la requête est exécutée    


            }
            catch (Exception ex)
            {
                // Une erreur est survenue: on ne valide pas la requête     

                Console.WriteLine("<body><script >alert('Requête non effectuée !!\nErreur: '" + ex.Message + "'');</script></body>");
            }
            finally
            {     // Libération des ressources     
                req.Dispose();
            }
            dr.Read();
            nb = dr.GetInt32(0);
            return nb;
        }

        public int CompterAgent(string agent)
        {
            DBConnectJDE c = new DBConnectJDE();
            OracleConnection conn = c.GetConnectionJDE();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            Int32 nb = 0;
            OracleCommand req = new OracleCommand
            {
                CommandText = "SELECT COUNT(YAALPH) AS nb FROM F55EMPME WHERE YAAN8 LIKE '%" + agent + "%' OR YAOEMP LIKE '%" + agent + "%' OR YAALPH LIKE '%" + agent + "%' ",
                Connection = conn,
                CommandType = CommandType.Text
            };
            try
            {
                // Exécution de la requête     
                dr = req.ExecuteReader();
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
                req.Dispose();
            }
            dr.Read();
            nb = dr.GetInt32(0);
            return nb;
        }

        //Verifier existence Medecin
        public int CompterMed(string med)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            Int32 nb = 0;
            OracleCommand req = new OracleCommand
            {
                CommandText = "SELECT COUNT(CODMEDEC) AS nb FROM MEDECIN WHERE CODMEDEC LIKE '%" + med + "%'  OR NOMMEDEC LIKE '%" + med + "%' OR TYPMEDEC LIKE '%" + med + "%' OR CODE_PREST LIKE '%" + med + "%' ",
                Connection = conn,
                CommandType = CommandType.Text
            };
            try
            {
                // Exécution de la requête     
                dr = req.ExecuteReader();
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
                req.Dispose();
            }
            dr.Read();
            nb = dr.GetInt32(0);
            return nb;
        }

        //Afiche agent avec ajax (Recherche Agent)
        public OracleDataReader GetAgent(string agent)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();

            OracleTransaction trans = conn.BeginTransaction();
            if (agent != null)
            {
                OracleCommand cmd = new OracleCommand
                {
                    CommandText = "SELECT MATR,MATR_NOUV, NOM,  CASE ETAB WHEN 1 THEN 'Actif' WHEN 4 THEN 'Retraité' WHEN 5 THEN 'Décédé' ELSE '?' END, SA FROM AGENT_TEMP WHERE MATR LIKE '%" + agent + "%' OR MATR_NOUV LIKE '%" + agent + "%' OR NOM LIKE '%" + agent + "%' ",
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
            }
            return dr;
        }

        //Affiche medecin avec ajax (Recherche Medecin)
        public OracleDataReader GetMed(string med)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();

            OracleTransaction trans = conn.BeginTransaction();
            if (med != null)
            {
                OracleCommand cmd = new OracleCommand
                {
                    CommandText = "SELECT IDENTIFIANT, NOM, CODE_PREST FROM UTILISATEUR WHERE  IDENTIFIANT LIKE '%" + med + "%' OR NOM LIKE '%" + med + "%' OR CODE_PREST LIKE '%" + med + "%' AND CODE_PREST IS NOT NULL",
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
            }
            return dr;
        }

        //Affiche le type client avec ajax (société)
        public OracleDataReader GetType(string codeSte)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT TYPE_CLI FROM STE WHERE CODE_STE = '" + codeSte + "' ",
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

        //Verifier le type client (société)
        public int CompteType(string codeSte)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            Int32 nb = 0;
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT COUNT(1) as nb FROM STE WHERE CODE_STE = '" + codeSte + "' AND TYPE_CLI = 'INTERNE' ",
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
        //Affichage sexe Agent
        public OracleDataReader AffichageSexeA(string matr)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT SEX FROM AGENT_TEMP WHERE MATR_NOUV = '" + matr + "' OR MATR = '" + matr + "' ",
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

        public int CompterAgentTemp(string matr)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            Int32 nb = 0;
            OracleCommand req = new OracleCommand
            {
                CommandText = "SELECT COUNT(NOM) AS nb FROM AGENT_TEMP WHERE MATR LIKE '%" + matr + "%' OR MATR_NOUV LIKE '%" + matr + "%' OR  NOM LIKE '%" + matr + "%'",
                Connection = conn,
                CommandType = CommandType.Text
            };
            try
            {
                // Exécution de la requête     
                dr = req.ExecuteReader();
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
                req.Dispose();
            }
            dr.Read();
            nb = dr.GetInt32(0);
            return nb;
        }

        //Affiche FAMILLE JDE ajax (table)
        public OracleDataReader GetJDE(string matr)
        {
            DBConnectJDE c = new DBConnectJDE();
            OracleConnection conn = c.GetConnectionJDE();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            nb = CompterAgentTemp(matr);
            if (nb == 0)
            {
                OracleCommand cmd = new OracleCommand
                {
                    CommandText = "SELECT a.YAAN8, a.YAOEMP , a.YAALPH , a.YADSC1 ,' ' , a.YAALPH1, CASE a.YATRDJ WHEN 0 THEN '-' ELSE  to_char(to_date(to_char(1900 + floor(a.YATRDJ/ 1000)),'YYYY') + mod(a.YATRDJ,1000) - 1, 'DD-MM-YYYY') END ," +

                    "b.ALADD1  FROM JIRDTA.F55EMPME a" +

                    " left join JIRDTA.F0116 b on ltrim(a.YAAN8)=ltrim(b.ALAN8) " +

                    "WHERE  a.YAAN8 = '" + matr + "' OR a.YAOEMP= '" + matr + "'",
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
            }
            else if (nb == 1)
            {
                OracleCommand cmd = new OracleCommand
                {
                    CommandText = "SELECT a.YAAN8, a.YAOEMP , a.YAALPH , a.YADSC1 , a.YASEX , a.YAALPH1, CASE a.YATRDJ WHEN 0 THEN '-' ELSE  to_char(to_date(to_char(1900 + floor(a.YATRDJ/ 1000)),'YYYY') + mod(a.YATRDJ,1000) - 1, 'DD-MM-YYYY') END," +

                    "b.ALADD1  FROM JIRDTA.F55EMPME a" +

                    " left join JIRDTA.F0116 b on ltrim(a.YAAN8)=ltrim(b.ALAN8) " +

                    " WHERE a.YADSC1 <> a.YAALPH AND a.YAAN8 = '" + matr + "' OR a.YAOEMP = '" + matr + "'",
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
            }
            return dr;
        }

        //Affiche AGENT JDE ajax (table)
        public OracleDataReader GetAgentJDE(string matr)
        {
            DBConnectJDE c = new DBConnectJDE();
            OracleConnection conn = c.GetConnectionJDE();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT a.YAAN8, a.YAOEMP , a.YAALPH , a.YADSC1 , ' ', a.YAALPH1, CASE a.YATRDJ WHEN 0 THEN '-' ELSE  to_char(to_date(to_char(1900 + floor(a.YATRDJ/ 1000)),'YYYY') + mod(a.YATRDJ,1000) - 1, 'DD-MM-YYYY') END ," +

                    "b.ALADD1  FROM JIRDTA.F55EMPME a" +

                    " left join JIRDTA.F0116 b on ltrim(a.YAAN8)=ltrim(b.ALAN8) " +

                    "WHERE  a.YAAN8 = '" + matr + "' OR a.YAOEMP= '" + matr + "'",
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

        //Vérifie l'existance du patient (pour les certificats)
        public int CompterNomPat(string nom)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            Int32 nb = 0;
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT COUNT(1) FROM CERTIFICAT_AG WHERE NOM = '" + nom + "' ",
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

        //Affiche l'état des certificats des patients
        public OracleDataReader GetCertifiact(string nom)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT CASE CERT_SCOL WHEN 'O' THEN 'Valide' WHEN NULL THEN 'Non valide' ELSE 'Non valide' END, CASE CERT_CELIB WHEN 'O' THEN 'Valide' WHEN NULL THEN 'Non valide' ELSE 'Non valide' END FROM CERTIFICAT_AG WHERE NOM = '" + nom + "' AND EXTRACT(YEAR FROM DATE_SAI) =EXTRACT(YEAR FROM SYSDATE)",
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

        //Calcule numero patient avec ajax
        public OracleDataReader GetNum(string codeMed)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT COUNT(IDENTIFIANT) + 1 AS num FROM FREQMALA_JDE WHERE (IDENTIFIANT = '" + codeMed + "') AND (TO_DATE(DFREQ, 'DD/MM/YYYY') = TO_DATE(SYSDATE, 'DD/MM/YYYY'))",
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

        //Liste les activitées (select)
        public OracleDataReader ListeAct()
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT CODE_ACT, LIBELLE FROM ACTIVITE ORDER BY LIBELLE ASC",
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

        //Calcul age patient
        public OracleDataReader CalculAge(string datenais)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT EXTRACT(YEAR FROM sysdate)-EXTRACT(YEAR FROM TO_DATE('" + datenais + "', 'DD-MM-YYYY') ) from DUAL",
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

        //Liste les sociétés (select)
        public OracleDataReader ListeSte()
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT CODE_STE, LIBELLE FROM STE ORDER BY LIBELLE ASC",
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

        //Liste les prestations (select)
        public OracleDataReader ListePrest(string codeAct)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT CODE_PREST,LIB_PREST FROM PRESTAT WHERE CODE_ACT= '" + codeAct + "' ORDER BY LIB_PREST ASC",
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

        //Liste les medecins (select)
        public OracleDataReader ListeMed(string codePrest)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT IDENTIFIANT FROM UTILISATEUR WHERE CODE_PREST= '" + codePrest + "'AND STATUT= 'Actif' ORDER BY IDENTIFIANT ASC",
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

        //Affiche liste d'attentes des fréquentations non traitées des Médecins 
        public OracleDataReader FreqAttente()
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();

            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT F.FREQMALA, F.IDENTIFIANT, F.NUMERO, F.NOM, F.AGE, F.SEXE, CASE P.CODE_ACT WHEN '101' THEN 'Consultation medecin' WHEN '201' THEN 'Sage femme' WHEN '201' THEN 'Consultation dentiste' END, P.CODE_PREST FROM FREQMALA_JDE F, PRESTAT P WHERE F.DFREQ IS NOT NULL AND F.HAMEDE IS NULL AND (TO_DATE(F.DFREQ, 'DD/MM/YYYY') = TO_DATE(SYSDATE, 'DD/MM/YYYY')) AND P.CODE_PREST = F.CODE_PREST",
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

        public OracleDataReader GetPat(string pat)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();

            OracleTransaction trans = conn.BeginTransaction();
            if (pat != null)
            {
                OracleCommand cmd = new OracleCommand
                {
                    CommandText = "SELECT FREQMALA, NOM FROM FREQMALA_JDE WHERE  NUMERO LIKE '%" + pat + "%' OR NOM LIKE '%" + pat + "%'  ",
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
            }
            return dr;
        }

        public int CompterPat(string pat)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            Int32 nb = 0;
            OracleCommand req = new OracleCommand
            {
                CommandText = "SELECT COUNT(NOM) AS nb FROM FREQMALA_JDE WHERE NUMERO LIKE '%" + pat + "%'  OR NOM LIKE '%" + pat + "%' ",
                Connection = conn,
                CommandType = CommandType.Text
            };
            try
            {
                // Exécution de la requête     
                dr = req.ExecuteReader();
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
                req.Dispose();
            }
            dr.Read();
            nb = dr.GetInt32(0);
            return nb;
        }

        public int CompterID(int id)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            int nb = 0;
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT COUNT(FREQMALA) FROM FREQMALA_JDE WHERE FREQMALA = '" + id + "'",
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
            nb = dr.GetInt16(0);
            return nb;
        }

        //Get la fréquentation de l'id
        public OracleDataReader GetFreq1(int id)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();

            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT FREQMALA, IDENTIFIANT, NOM, AGE, SEXE, NUMERO, CODE_ACT, CODE_PREST, ADRESSE FROM FREQMALA_JDE WHERE FREQMALA = '" + id + "'",
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
