using System;
using System.Collections.Generic;
using System.Text;

namespace GerarClasses.Classes
{
    public static class DadosDaClasse
    {
        // cria os dados do construtor e atualiza os parametros;
        public static void CriarConstrutor(Parametros parm)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"public {parm.NomeDaClasse} (");
            for (int i = 0; i < parm.ListaDeAtributos.Count; i++)
            {
                string nomeLow = char.ToLower(parm.ListaDeAtributos[i].Nome[0]) + parm.ListaDeAtributos[i].Nome.Substring(1);
                sb.Append(parm.ListaDeAtributos[i].Tipo + " " + nomeLow);
                if (i < parm.ListaDeAtributos.Count - 1)
                    sb.Append(", ");
            }
            sb.AppendLine(")");
            sb.AppendLine("        {");
            foreach (var item in parm.ListaDeAtributos)
            {
                string nomeLow = char.ToLower(item.Nome[0]) + item.Nome.Substring(1);
                sb.AppendLine($@"            {item.Nome} = {nomeLow};");
            }
            sb.AppendLine("        }");
            parm.Construtor = sb.ToString();
        }


        public static void CriarAtributos(Parametros parm, string tipoAcessoSet)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in parm.ListaDeAtributos)
            {
                string acesso = "{ get; " + tipoAcessoSet + " set; }";
                sb.AppendLine($"        public {item.Tipo} {item.Nome} {acesso}");
                sb.AppendLine("");

            }
            parm.Atributos = sb.ToString();
        }


        // cria uma lista de atributos com o nome do objeto (prefixo) para criar contrutores;
        public static string ListaDeAtributosParaConstrutor(Parametros parm, string prefixoObjeto, bool comIdentificacao)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < parm.ListaDeAtributos.Count; i++)
            {
                if (comIdentificacao)
                    sb.Append(Util.PrimeiroCaracterLowerCase(parm.ListaDeAtributos[i].Nome) + ": " + prefixoObjeto + "." + parm.ListaDeAtributos[i].Nome);
                else
                    sb.Append(Util.PrimeiroCaracterLowerCase( prefixoObjeto + "." + parm.ListaDeAtributos[i].Nome));
                if (i < parm.ListaDeAtributos.Count - 1)
                    sb.AppendLine(", ");
            }
            return sb.ToString();
        }



    }
}
