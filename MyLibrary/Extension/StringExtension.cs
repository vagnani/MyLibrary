using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.StringExtension
{
    public static partial class StringExtension
    {
        public static void RemoveWord(this string str, string parolaDaRimuovere, Action<string> OpzionePrimaRimozione = null)
        {
            OpzionePrimaRimozione(str);
            string newStr = str.GetRemoveWord(parolaDaRimuovere, null);
            str = newStr;
        }
        
        public static string GetRemoveWord(this string str, string parolaDaRimuovere, Action<string> OpzionePrimaRimozione = null)
        {
            string strCopia = str;
            if (OpzionePrimaRimozione != null)
            {
                OpzionePrimaRimozione(strCopia);
            }

            byte lenghtWordToRemove = (byte)parolaDaRimuovere.Length;
            byte indexWordToRemove = (byte)str.IndexOf(parolaDaRimuovere);
            string newStr = strCopia.Remove(indexWordToRemove, lenghtWordToRemove);
            return newStr;
        }
    }
}
