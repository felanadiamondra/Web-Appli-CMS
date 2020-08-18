using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebCMSJIR.Models;
using WebCMSJIR.Models.connexion;
using WebCMSJIR.Views.Home;
using WebCMSJIR.Views.Utilisateur;
using Oracle.ManagedDataAccess.Client;
using System.Data;


namespace WebCMSJIR.Controllers
{
    public class HomeController : Controller
    {
        OracleDataReader dr;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index(string Ident )
        {
            return View("Index");
        }

        [HttpPost] //action du boutton connexion
        public IActionResult Index(string login, string mdp, string GROUPE)
        {
            login user = new login();   //connexion avec la classe connexion dans Models
            FonctionHome user1 = new FonctionHome(); //connexion avec la classe dans FonctionHome
            int nbr = user.Sp_Login(login, mdp, GROUPE);
            string statut = user1.GetStatut(login);
            GlobalVariable.ImportantData = user1.getLogin(login);
            string ac = "Accueil";
            string ad = "Administrateur";
            string inf = "103";
            string med = "101";
          
            string act = "Actif";
            string inact = "Inactif";
            if (nbr == 1 && GROUPE.Equals(ad) && statut.Equals(act) )
            {
                return RedirectToAction("Index", "Utilisateur");
            }
            else if (nbr == 1 && GROUPE.Equals(ac) && statut.Equals(act))
            {
                return RedirectToAction("Index", "Frequentation");
            }
            else if (nbr == 1 && GROUPE.Equals(ac) && statut.Equals(inact))
            {
                TempData["message"] = "Votre compte est desactive !";
                return View();
            }
            else if (nbr == 1 && GROUPE.Equals(ad) && statut.Equals(inact))
            {
                TempData["message"] = "Votre compte est desactive !";
                return View();
            }
            else if (nbr == 1 && GROUPE.Equals(inf) && statut.Equals(act))
            {
                return RedirectToAction("Index", "Infirmerie");
            }
            else if (nbr == 1 && GROUPE.Equals(inf) && statut.Equals(inact))
            {
                TempData["message"] = "Votre compte est desactive !";
                return View();
            }
            else if (nbr == 1 && GROUPE.Equals(med) && statut.Equals(act))
            {
                return RedirectToAction("Index", "Medecin" , new {Log = login});
            }
            else if (nbr == 1 && GROUPE.Equals(med) && statut.Equals(inact))
            {
                TempData["message"] = "Votre compte est desactive !";
                return View();
            }
            else
            {
                TempData["message"] = " Veuillez reessayer !";
                return View();
            }
        }

        public IActionResult Configurer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Configurer(string identifiant, string mdp)
        {
            login user = new login();
            int nbr = user.Config_Login(identifiant, mdp);
            if (nbr == 1)
            {
                return RedirectToAction("Index", "Utilisateur");
            }
            else
            {
                TempData["message"] = " Veuillez reessayer !";
                return View();
            }
        }

        public IActionResult Parametre()
        {
            return View();
        }

        public IActionResult ConfirmeMdp(string ID ,string Amdp ,string Nmdp ,string login)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            FonctionUser user1 = new FonctionUser();
            int nb = user1.CompterUser(ID);
            if(nb == 1)
            {               
                int compt = user1.ComptMdp(Amdp,ID);
                if(compt == 1)
                {
                    if(Nmdp!= null && login == null)
                    {
                        OracleCommand cmd = new OracleCommand
                        {
                            CommandText = "UPDATE UTILISATEUR SET PASSWORD='" + Nmdp + "', DATE_MOD= sysdate , MODIFIANT='" + ID + "' WHERE IDENTIFIANT='" + ID + "'",
                            Connection = conn,
                            CommandType = CommandType.Text
                        };
                        try
                        {
                            // Exécution de la requête     

                            dr = cmd.ExecuteReader();
                            // On soumet la requête au serveur: tout s'est bien déroulé , la requête est exécutée    
                            trans.Commit();
                            TempData["TEXT"] = "Votre nouveau mot de passe est " + Nmdp + " !";
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
                    else if(login!= null && Nmdp == null)
                    {
                        OracleCommand cmd = new OracleCommand
                        {
                            CommandText = "UPDATE UTILISATEUR SET LOGIN ='" + login + "', DATE_MOD= sysdate , MODIFIANT='"+ ID +"' WHERE IDENTIFIANT='" + ID + "'",
                            Connection = conn,
                            CommandType = CommandType.Text
                        };
                        try
                        {
                            // Exécution de la requête     

                            dr = cmd.ExecuteReader();
                            // On soumet la requête au serveur: tout s'est bien déroulé , la requête est exécutée    
                            trans.Commit();
                            TempData["TEXT"] = "Votre nouveau Login est " + login + "";
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
                    else if(Nmdp!=null && login != null)
                    {
                        OracleCommand cmd = new OracleCommand
                        {
                            CommandText = "UPDATE UTILISATEUR SET PASSWORD='" + Nmdp + "' , LOGIN ='" + login + "', DATE_MOD= sysdate , MODIFIANT='" + ID + "' WHERE IDENTIFIANT='" + ID + "'",
                            Connection = conn,
                            CommandType = CommandType.Text
                        };
                        try
                        {
                            // Exécution de la requête     

                            dr = cmd.ExecuteReader();
                            // On soumet la requête au serveur: tout s'est bien déroulé , la requête est exécutée    
                            trans.Commit();
                            TempData["TEXT"] = "Votre nouveau mot de passe :" + Nmdp + " et login : " + login + "";
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
                    else if(Nmdp == null && login== null)
                    {
                        TempData["TEXT"] = "Veuillez remplir le/les champs à modifier !";
                        return RedirectToAction("Parametre", "Home");

                    }
                }
                else
                {
                    TempData["TEXT"] = "Mot de passe actuel " + Amdp + " incorrect !! Veuillez reessayer !";
                    return RedirectToAction("Parametre", "Home");
                }
            }
            else
            {
                TempData["TEXT"] = "Identifiant  "+ ID +"  introuvable !! Veuillez reessayer !";
                return RedirectToAction("Parametre", "Home");
            }
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
