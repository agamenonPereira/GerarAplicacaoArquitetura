using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GerarClasses.Classes
{
    public static partial class GerarDomain
    {
        private static readonly string pathCommandsTemplate = @"Templates\Domain\Commands\";

        // o prefixo informa: Alterar, Excluir, Incluir;
        public static void Commands(Parametros param, string prefixo)
        {
            DadosDaClasse.CriarAtributos(param, "protected");

            // GERAR Commands;
            string template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathCommandsTemplate, @"ClasseCommand.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            template = template.Replace("{{Classe}}", param.NomeDaClasse);
            template = template.Replace("{{Atributos}}", param.Atributos);
            var nomeArquivo = $"{param.NomeDaClasse}Command.cs";
            GravarResultado.Gravar(true, template, nomeArquivo, param.EnderecoDoProjetoDomain, @"Commands\");

            // GERAR CommandClasseCommand;
            template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathCommandsTemplate, @"CommandoClasseCommand.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            template = template.Replace("{{Classe}}", param.NomeDaClasse);
            template = template.Replace("{{PrefixoClasse}}", prefixo + param.NomeDaClasse);
            var construtorComPrefixo = param.Construtor;
            construtorComPrefixo = Util.TrocarPrimeiraOcorrencia(construtorComPrefixo, param.NomeDaClasse, prefixo + param.NomeDaClasse + "Command");
            template = template.Replace("{{ConstrutorDaClasseComPrefixo}}", construtorComPrefixo);
            nomeArquivo = $"{prefixo}{param.NomeDaClasse}Command.cs";
            GravarResultado.Gravar(true, template, nomeArquivo, param.EnderecoDoProjetoDomain, @"Commands");

        }

    }
}
