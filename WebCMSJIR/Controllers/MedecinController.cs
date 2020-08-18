using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCMSJIR.Views.Medecin;
using Oracle.ManagedDataAccess.Client;
using WebCMSJIR.Models;

namespace WebCMSJIR.Controllers
{
    public class MedecinController : Controller
    {
        OracleDataReader dr;
        public IActionResult Index(string Log)
        {
            FonctionMed fMed = new FonctionMed();
            int b = fMed.Comptlog(Log);
            if (b != 0)
            {
                GlobalVariable.GlobalVar = Log;
                string id = fMed.getIdent(Log);
                GlobalVariable.ImportantData = id;
                ViewBag.Message = Log;
                return View();
            }
            else
            {
                return RedirectToAction("Identifiant", "Trash");
            }
        }
        public IActionResult updateFreq(string obs, string daterdz, int Jrepos, int num)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "UPDATE FREQMALA_JDE SET AVIS_MEDE ='" + obs + "' , DATE_RENDEZ_VOUS =TO_DATE('" + daterdz + "', 'DD/MM/YYYY HH24:MI:SS') , JREPOS ='" + Jrepos + "' , HAMEDE = SYSDATE WHERE NUMERO= '" + num + "' AND (TO_DATE(DFREQ, 'DD/MM/YYYY') = TO_DATE(SYSDATE, 'DD/MM/YYYY')) AND IDENTIFIANT = '" + GlobalVariable.ImportantData + "'  ",
                Connection = conn,
                CommandType = CommandType.Text
            };
            try
            {
                // Exécution de la requête     
                dr = cmd.ExecuteReader();
                // On soumet la requête au serveur: tout s'est bien déroulé , la requête est exécutée    
                trans.Commit();
                TempData["text"] = "Traitement reussi du patient " + num + " ! ";
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
            return RedirectToAction("Index", "Medecin", new { Log = GlobalVariable.GlobalVar });
        }
    }
}
