﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotekSystem
{
    internal static class Constrains
    {
        public static (bool, string) CheckUser(string PN)//Ska kolla usern om den uppfyller krav för ålder m.m.
        {
            string year = PN.Substring(0, 2);
            string month = PN.Substring(2, 2);
            string days = PN.Substring(4, 2);
            DateTime checkAge = DateTime.Parse($"{year}/{month}/{days}");
            TimeSpan ageOk = DateTime.Now.Subtract(checkAge);
            
            if (ageOk.TotalDays > 6570)
            {
                return (true, "Du har åldern inne för snusk");
            }          
            return (false, "Du är för ung");           
        }
    }
}
