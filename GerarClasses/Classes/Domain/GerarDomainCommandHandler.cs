using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GerarClasses.Classes
{
    public static partial class GerarDomain
    {
        private static readonly string pathCommandHandlerTemplate = @"Templates\Domain\CommandHandlers\";

        // o prefixo informa: Alterar, Alterada, Excluido, Excluida;
        public static void CommandHandler(Parametros param, string prefixo1, string prefixo2, string prefixo3, string sufixo1, string sufixo2, string sufixo3)
        {
            // GERAR CommandHandler (aggregate root);
            string template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathCommandHandlerTemplate, @"CommandHandler.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            var nomeArquivo = "CommandHandler.cs";
            GravarResultado.Gravar(true, template, nomeArquivo, param.EnderecoDoProjetoDomain, @"CommandHandlers\");

            // GERAR CommandHandler;
            string classeLower = Util.PrimeiroCaracterLowerCase(param.NomeDaClasse);
            var listaDeAtributosParaConstrutorObj = DadosDaClasse.ListaDeAtributosParaConstrutor(param, classeLower, true);
            var listaDeAtributosParaConstrutorMessage = DadosDaClasse.ListaDeAtributosParaConstrutor(param, "message", true);
            string pfx1 = prefixo1 + param.NomeDaClasse;
            string pfx2 = prefixo2 + param.NomeDaClasse;
            string pfx3 = prefixo3 + param.NomeDaClasse;
            string sfx1 = param.NomeDaClasse + sufixo1;
            string sfx2 = param.NomeDaClasse + sufixo2;
            string sfx3 = param.NomeDaClasse + sufixo3;
            template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathCommandHandlerTemplate, @"ClasseCommandHandler.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            template = template.Replace("{{Classe}}", param.NomeDaClasse);
            template = template.Replace("{{ClasseLower}}", classeLower);
            template = template.Replace("{{Prefixo1Classe}}", pfx1);
            template = template.Replace("{{Prefixo2Classe}}", pfx2);
            template = template.Replace("{{Prefixo3Classe}}", pfx3);
            template = template.Replace("{{ClasseSufixo1}}", sfx1);
            template = template.Replace("{{ClasseSufixo2}}", sfx2);
            template = template.Replace("{{ClasseSufixo3}}", sfx3);
            template = template.Replace("{{Prefixo1}}", prefixo1);
            template = template.Replace("{{Prefixo2}}", prefixo2);
            template = template.Replace("{{Prefixo3}}", prefixo3);
            template = template.Replace("{{ListaDeAtributosParaConstrutorMessage}}", listaDeAtributosParaConstrutorMessage);
            template = template.Replace("{{ListaDeAtributosParaConstrutorObj}}", listaDeAtributosParaConstrutorObj);
            nomeArquivo = $"{param.NomeDaClasse}CommandHandler.cs";
            GravarResultado.Gravar(true, template, nomeArquivo, param.EnderecoDoProjetoDomain, @"CommandHandlers\");
        }

    }
}
