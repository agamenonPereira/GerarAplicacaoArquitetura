using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GerarClasses.Classes
{
    public static partial class GerarDomain
    {
        private static readonly string pathEventHandlerTemplate = @"Templates\Domain\EventHandlers\";

        // o sufixo informa: Alterado, Alterada, Excluido, Excluida;
        public static void EventHandler(Parametros param, string sufixo1, string sufixo2, string sufixo3)
        {
            // GERAR EventHandler;
            string sfx1 = param.NomeDaClasse + sufixo1;
            string sfx2 = param.NomeDaClasse + sufixo2;
            string sfx3 = param.NomeDaClasse + sufixo3;
            string template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathEventHandlerTemplate, @"ClasseEventHandler.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            template = template.Replace("{{Classe}}", param.NomeDaClasse);
            template = template.Replace("{{ClasseSufixo1}}", sfx1);
            template = template.Replace("{{ClasseSufixo2}}", sfx2);
            template = template.Replace("{{ClasseSufixo3}}", sfx3);
            var nomeArquivo = $"{param.NomeDaClasse}EventHandler.cs";
            GravarResultado.Gravar(true, template, nomeArquivo, param.EnderecoDoProjetoDomain, @"EventHandlers\");
        }

    }
}
