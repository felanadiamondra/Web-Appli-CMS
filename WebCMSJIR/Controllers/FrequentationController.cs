using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using WebCMSJIR.Views.Frequentation;
using System;
using WebCMSJIR.Models;
using System.Data;
using WebCMSJIR.Views.Societe;

namespace WebCMSJIR.Controllers
{
    public class FrequentationController : Controller
    {
        OracleDataReader dr;

        public IActionResult Index()
        {
            return View("Index1", "Frequentation");
        }

        //Fin de recherche
        public IActionResult AfficherTypeSTE(string codeSte)
        {
            FonctionSociete ste = new FonctionSociete();
            int nb = ste.CompterSte(codeSte);
            if (nb != 0)
            {
                ViewBag.Message = codeSte;
                FonctionFreq fr = new FonctionFreq();
                int t = fr.CompteType(codeSte);
                if (t == 1)
                {
                    return View("Interne", "Frequentation");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Fin", "Frequentation");
            }
        }

        public IActionResult Prestation(string codeAct)
        {
            ViewBag.Message = codeAct;
            return View();
        }

        public IActionResult AfficherMed(string codePrest)
        {
            ViewBag.Message = codePrest;
            return View();
        }

        public IActionResult AfficherJDE(string matricule)
        {
            FonctionFreq fFreq = new FonctionFreq();
            int nb = fFreq.CompterAgent(matricule);
            if (nb != 0)
            {
                ViewBag.Message = matricule;
                return View();
            }
            else
            {
                return RedirectToAction("Fin", "Frequentation");
            }
        }

        public IActionResult AfficheTypeSte(string codeSte)
        {
            ViewBag.Message = codeSte;
            return View();
        }

        public IActionResult AfficherNumero(string codeMed)
        {
            ViewBag.Message = codeMed;
            return View();
        }
        public IActionResult AjoutFreq(string ste, string typeSte, string matPat, string nomAG, string SA, int etab, string nomPat, int typePat, string dateNais, int agePat, char sexe, string adr, int numero, string natConsul, string codeMed, string act, string prest, string sce, string dir, string aMatrPat)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            FonctionFreq fFreq = new FonctionFreq();
            int nb = fFreq.CompteType(ste);

            OracleTransaction trans = conn.BeginTransaction();
            //string type = "INTERNE";
            if (nb==1)
            {
                OracleCommand cmd = new OracleCommand
                {
                    CommandText = "INSERT INTO FREQMALA_JDE(NUMERO , MATR_NOUV , MATR, ETAB , CODMEDE  , STE , TYPE_CLI , TYPAT , CODE_SOUS_ACT , CODE_PREST , NAT_CONSULT , NOUV_NUM_SA , NOM , DNAIS , ADRESSE, SEXE, DFREQ , SERVICE, DIRECTION, HACMS) VALUES('" + numero + "' , '" + matPat + "' ,'" + aMatrPat + "', '" + etab + "', '" + codeMed + "' , '" + ste + "' , '" + typeSte + "' , '" + typePat + "', '" + act + "' , '" + prest + "' , '" + natConsul + "' , '" + SA + "' , '" + nomPat + "',TO_DATE('" + dateNais + "', 'DD/MM/YYYY') , '" + adr + "' , '" + sexe + "' , to_char(sysdate, 'dd/mm/yy'), '" + sce + "', '"+ dir +"', to_char(sysdate, 'hh24:mi:ss'))",
                    Connection = conn,
                    CommandType = CommandType.Text
                };
                try
                {
                    // Exécution de la requête     
                    dr = cmd.ExecuteReader();
                    // On soumet la requête au serveur: tout s'est bien déroulé , la requête est exécutée    
                    trans.Commit();
                    TempData["text"] = "Insertion reussie";
                    conn.Close();
                }
                catch (Exception ex)
                {
                    // Une erreur est survenue: on ne valide pas la requête     
                    trans.Rollback();
                    TempData["text"] = "Requete non effectuee \nErreur: " + ex.Message;
                }
                finally
                {     // Libération des ressources     
                    cmd.Dispose();
                }
            }
            return RedirectToAction("Index", "Frequentation");
        }

        public IActionResult AfficherAgent(string agent)
        {
            if(agent != null)
            {
                FonctionFreq fFreq = new FonctionFreq();
                int nbA = fFreq.CompterAgent(agent);
                if (nbA != 0)
                {
                    ViewBag.Message = agent;
                    return View();
                }
                else
                {
                    return RedirectToAction("Agent", "Trash");
                }

            }
            else
            {
                return RedirectToAction("Fin", "Frequentation");
            }
        }

        public IActionResult AfficherModif(string matr, string tpat, string med)
        {
            ViewBag.Message = matr;
            ViewBag.Type = tpat;
            ViewBag.Medecin = med;
            return View();
        }

        public IActionResult NouvChamp()
        {
            return View();
        }

        /*public IActionResult UpdatePatient(string nomP, string Amatr, string Nmatr, string typeP, string numP, string medP)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            //string type = "INTERNE";
         
                OracleCommand cmd = new OracleCommand
                {
                    CommandText = "SELECT * FROM FREQMALA_JDE",
                    Connection = conn,
                    CommandType = CommandType.Text
                };
            try
            {
                // Exécution de la requête     
                dr = cmd.ExecuteReader();
                // On soumet la requête au serveur: tout s'est bien déroulé , la requête est exécutée    
                trans.Commit();
                TempData["text"] = "Insertion reussie";
                conn.Close();
            }
            catch (Exception ex)
            {
                // Une erreur est survenue: on ne valide pas la requête     
                trans.Rollback();
                TempData["text"] = "Requete non effectuee \nErreur: " + ex.Message;
            }
            finally
            {     // Libération des ressources     
                cmd.Dispose();
            }
            return RedirectToAction("Index", "Frequentation");
        }*/
        public IActionResult AfficheMed(string med)
        {
            if (med != null)
            {
                FonctionFreq fFreq = new FonctionFreq();
                int nbM = fFreq.CompterMed(med);
                if (nbM != 0)
                {
                    ViewBag.Message = med;
                    return View();
                }
                else
                {
                    return RedirectToAction("Medecin", "Trash");
                }

            }
            else
            {
                return RedirectToAction("Fin", "Frequentation");
            }
        }

    }
}   