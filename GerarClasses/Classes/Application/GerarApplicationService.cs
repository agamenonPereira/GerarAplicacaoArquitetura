using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GerarClasses.Classes
{
    public static partial class GerarApplication
    {
        private static readonly string pathApplicationServiceTemplate = @"Templates\Application\Services\";

        public static void Service(Parametros param, string nomeDoMetodoObterTodos)
        {
            // GERAR Service;
            var classeLow = Util.PrimeiroCaracterLowerCase(param.NomeDaClasse);
            string template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathApplicationServiceTemplate, @"Service.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            template = template.Replace("{{Classe}}", param.NomeDaClasse);
            template = template.Replace("{{ClasseLow}}", classeLow);
            Atributos primeiroAtributo = param.ListaDeAtributos[0];
            template = template.Replace("{{NomeId}}", Util.PrimeiroCaracterLowerCase(primeiroAtributo.Nome));
            template = template.Replace("{{TipoId}}", primeiroAtributo.Tipo);
            template = template.Replace("{{NomeDoMetodoObterTodos}}", nomeDoMetodoObterTodos);
            var nomeArquivo = $"{param.NomeDaClasse}AppService.cs";
            GravarResultado.Gravar(true, template, nomeArquivo, param.EnderecoDoProjetoApplication, @"Services\");
        }

    }
}
