using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotekSystem
{
    public class Constrains
    {
        public static (bool, string) CheckUser(string PN)//Ska kolla usern om den uppfyller krav för ålder m.m.
        {
            string year;
            string month;
            string days;
            TimeSpan ageOk;
            try
            {
                year = PN.Substring(0, 2);
                month = PN.Substring(2, 2);
                days = PN.Substring(4, 2);
                DateTime checkAge = DateTime.Parse($"{year}/{month}/{days}");
                ageOk = DateTime.Now.Subtract(checkAge);
            }
            catch (Exception)
            {
                return (false, "Felaktig inmatning");
            }
           
            if (ageOk.TotalDays > 6570)
            {
                return (true, "Du har åldern inne för snusk");
            }          
            return (false, "Du är för ung");     
            
        }
    }
}
