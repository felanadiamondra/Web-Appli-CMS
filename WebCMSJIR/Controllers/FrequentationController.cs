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
        public IActionResult AjoutFreq(string ste, string typeSte, string matr, string nomAG, string SA, int etab, string nomPat, int typePat, string dateNais, int agePat, char sexe, string adr, int numero, string natConsul, string codeMed, string act, string prest)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();

            FonctionFreq f = new FonctionFreq();
            int id = f.IDFreq();
            int ide = id + 100;

            OracleTransaction trans = conn.BeginTransaction();
            string type = "INTERNE";
            if (typeSte.Equals(type))
            {
                OracleCommand cmd = new OracleCommand
                {
                    CommandText = "INSERT INTO FREQMALA_JDE(FREQMALA, NUMERO , MATR , ETAB , IDENTIFIANT  , STE , TYPE_CLI , TYPAT , CODE_ACT , CODE_PREST , NAT_CONSULT , SA , NOM , DNAIS , ADRESSE, SEXE, AGE, DFREQ ) VALUES('" + ide + "' , '" + numero + "' , '" + matr + "' ,'" + etab + "', '" + codeMed + "' , '" + ste + "' , '" + typeSte + "' , '" + typePat + "', '" + act + "' , '" + prest + "' , '" + natConsul + "' , '" + SA + "' , '" + nomPat + "',TO_DATE('" + dateNais + "', 'DD/MM/YYYY') , '" + adr + "' , '" + sexe + "', '" + agePat + "' , sysdate)",
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
            else
            {
                OracleCommand cmd = new OracleCommand
                {
                    CommandText = "INSERT INTO FREQMALA_JDE(FREQMALA, NUMERO , IDENTIFIANT , STE , TYPE_CLI , CODE_ACT , CODE_PREST , NAT_CONSULT, NOM, DNAIS , ADRESSE, SEXE, AGE, DFREQ ) VALUES('" + id + "' , '" + numero + "' , '" + codeMed + "' , '" + ste + "' , '" + typeSte + "' , '" + act + "' , '" + prest + "' , '" + natConsul + "' , '" + nomPat + "', TO_CHAR(TO_DATE('" + dateNais + "', 'DD/MM/YYYY'), 'DD/MM/YYYY') , '" + adr + "', '" + sexe + "', '" + agePat + "',  sysdate)",
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
                    TempData["text"] = "Requete non effectue \nErreur: " + ex.Message;
                }
                finally
                {     // Libération des ressources     
                    cmd.Dispose();
                }
            }
            return RedirectToAction("Index", "Frequentation");
        }

    }
}   