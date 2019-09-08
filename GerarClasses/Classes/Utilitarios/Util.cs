using System;
using System.Collections.Generic;
using System.Text;

namespace GerarClasses.Classes
{
    public static class Util
    {
        public static string TrocarPrimeiraOcorrencia(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }


        public static string PrimeiroCaracterLowerCase(string texto)
        {
            string nomeLow = texto;
            if (nomeLow.Length > 0)
                nomeLow = char.ToLower(nomeLow[0]) + nomeLow.Substring(1);
            return nomeLow;
        }

        public static string AtualizarTipo(string tipo)
        {
            string tp = tipo.Replace("System.", "");
            switch (tp)
            {
                case "Int":
                case "Double":
                case "String":
                    tp = tp.ToLower();
                    break;
                case "Boolean":
                    tp = "bool";
                    break;
                case "Int32":
                    tp = "int";
                    break;
                case "Int64":
                    tp = "long";
                    break;
                default: break;
            }
            return tp;
        }





    }
}
