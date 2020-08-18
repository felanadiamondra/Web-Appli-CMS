using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace WebCMSJIR.Controllers
{
    public class InfirmerieController : Controller
    {
        OracleDataReader dr;
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult ValiderFreq(string idPat, double tempPat, double tamaxPat, double taminPat, double pulsPat, double poidsPat, double taillePat, double pcPat, double albuminePat, double glycemiePat)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "UPDATE FREQMALA_JDE SET TEMP = '" + tempPat + "' , TAMAX = '" + tamaxPat + "' , TAMIN ='" + taminPat + "' , PULLS = '" + pulsPat + "' , POIDS = '" + poidsPat + "', PC = '" + pcPat + "' , ALBUM = '" + albuminePat + "' , GLICEMIE = '" + glycemiePat + "' , HACMS = TO_DATE(SYSDATE, 'HH24:MI:SS') WHERE FREQMALA ='" + idPat + "'",
                Connection = conn,
                CommandType = CommandType.Text
            };
            try
            {
                // Exécution de la requête     
                dr = cmd.ExecuteReader();
                // On soumet la requête au serveur: tout s'est bien déroulé , la requête est exécutée    
                trans.Commit();
                conn.Close();
                TempData["text"] = "Donnee enregistree successivement !";
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

            return RedirectToAction("Index", "Infirmerie");
        }
    }
}
