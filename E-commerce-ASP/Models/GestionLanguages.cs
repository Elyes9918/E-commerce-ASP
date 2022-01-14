﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace E_commerce_ASP.Models
{
    public class GestionLanguages
    {

        public static List<Languages> AvailableLanguages = new List<Languages>
                {
            new Languages {LanFullName="[English]", LangCultureName="en"},
            new Languages {LanFullName="[Francais]", LangCultureName="fr"},
            };
        
        //voir si la langue demandée est autorisée
        public static bool IsLanguageAvailable(string lang)
        {
            return AvailableLanguages.Where(a => a.LangCultureName.Equals(lang)).FirstOrDefault() != null ? true : false;
        }
        
        //Récupererlangue par défaut
        public static string GetDefaultLanguage()
        {
            return AvailableLanguages[0].LangCultureName;
        }
        public void SetLanguage(string lang)
        {
            try
            {
                if (!IsLanguageAvailable(lang))
                    lang = GetDefaultLanguage();
                var cultureInfo = new CultureInfo(lang);
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
                HttpCookie langCookie = new HttpCookie("culture", lang);
                langCookie.Expires = DateTime.Now.AddYears(1);
                HttpContext.Current.Response.Cookies.Add(langCookie);
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
        }






    }
}