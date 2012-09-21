using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcHowToChangeLabel.Models;
using System.Globalization;
//using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace MvcHowToChangeLabel.Controllers
{
    public class LabelChangeController : Controller
    {

        public ActionResult LabelView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LabelView(LabelChangeModel model, string Command)
        {
            
            //if (ModelState.IsValid)
            //{
            //    model.UserName = "xx";                
            //}
            //ModelState.AddModelError("", "Hvorfor udfylder den ikke textboxen...");

            // Problemer med MVC:
            // -Det var ikke tiltænkt at man ændrer en labels værdi via kode
            // -Textbox ændring via kode er ALT for besværligt
            // -Der er ikke rigtig nogen funktionalitet i MVC til at afgøre hvilken knap der
            //   er trykket på... kun en start funktion og en funktion til at håndtere
            //   submits
            //   I eksempler online vises ofte hvordan value på submit knapperne bruges
            //   til at afgøre hvilken knap der er trykket, men det virker som en
            //   UTROLIG dårlig ide, da value slår igennem på teksten der vises på knappen
            //   og navnet ofte vil blive ændret i koden, alt efter
            //   sprogvalg og andre ting...
            //   Jeg har brugt value her, da jeg ikke kunne finde et bedre eksempel !!!
            // - Meget af måden MVC kode er "Wired" sammen, er efter navnekonvention,
            //   f.eks. /LabelChange/LabelView som så skal finde en LabelChangeController
            //   dette virker som en meget dårlig ide generelt, da det åbner for en masse
            //   problemstillinger ved fejlindtastninger og dobbeltkonfekt. Det er at gå 
            //   tilbage i tiden med programudvikling fordi det kræver for meget af
            //   udvikleren. Hvis der går galt bruger man meget tid på at finde fejlen..

            switch (Command)
                {
                    case "Skift Textbox Metode1":
                        // ***** SKIFT AF TEXTBOX VALUE, METODE1 ***************************
                        // Dette virker. Værdien fra model.UserName kommer med til denne funktion,
                        //  men ryger ikke med til viewet senere, så der skal bruges setmodelvalue...
                        //ModelState.SetModelValue("UserName", new ValueProviderResult("Ny værdi .. + (" + model.UserName + ")",string.Empty,new CultureInfo("en-US")));
                        // eller
                        ModelState["UserName"].Value = new ValueProviderResult("Ny værdi .. + (" + model.UserName + ")", string.Empty, new CultureInfo("en-US"));
                        break;
                    case "Skift Textbox Metode2":
                        // ***** SKIFT AF TEXTBOX VALUE, METODE2 (Ikke anbefalet) ***************************
                        // Denne tilgang er måske problematisk, da den muligvis også clearer
                        // Model errors... så input validering ryger....
                        model.UserName = "Ny værdi .. + (" + model.UserName + ")";
                        ModelState.Clear();
                        break;
                    case "Skift Label":

                        MyDisplayName Label1 = new MyDisplayName(0);
                        Label1.LabelValue = model.UserName;

                        break;
                }



            // If we got this far, something failed, redisplay form
            return View(model);
        }

    }
}
