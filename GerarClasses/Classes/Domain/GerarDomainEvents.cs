using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GerarClasses.Classes
{
    public static partial class GerarDomain
    {
        private static readonly string pathEventsTemplate = @"Templates\Domain\Events\";

        // o sufixo informa: Alterado, Alterada, Excluido, Excluida;
        public static void Events(Parametros param, string sufixo)
        {
            // GERAR Events;
            string template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathEventsTemplate, @"ClasseEvent.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            template = template.Replace("{{ClasseSufixo}}", param.NomeDaClasse + sufixo);
            template = template.Replace("{{Atributos}}", param.Atributos);
            var construtorComSufixo = param.Construtor;
            construtorComSufixo = Util.TrocarPrimeiraOcorrencia(construtorComSufixo, param.NomeDaClasse, param.NomeDaClasse + sufixo + "Event");
            template = template.Replace("{{ConstrutorDaClasseComSufixo}}", construtorComSufixo);
            var nomeArquivo = $"{param.NomeDaClasse}{sufixo}Event.cs";
            GravarResultado.Gravar(true, template, nomeArquivo, param.EnderecoDoProjetoDomain, @"Events");
        }

    }
}
