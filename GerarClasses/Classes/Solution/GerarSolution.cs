using System;
using System.Collections.Generic;
using System.Text;

namespace GerarClasses.Classes
{
    public static class GerarSolution
    {
        private static readonly string pathSolutionTemplate = @"Templates\Solution\";

        public static void GerarProjeto(Parametros param)
        {
            // GERAR SOLUTION PROJECT;
            string template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathSolutionTemplate, @"Solution.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            var nomeArquivo = $"{param.NomeDoSistema}.sln";
            GravarResultado.Gravar(false, template, nomeArquivo, param.EnderecoDaPastaDoSistemaRaiz);

        }

    }
}
