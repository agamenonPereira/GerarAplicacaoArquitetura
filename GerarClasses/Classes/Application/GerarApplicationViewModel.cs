using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GerarClasses.Classes
{
    public static partial class GerarApplication
    {
        private static readonly string pathApplicationViewModelTemplate = @"Templates\Application\ViewModels\";

        public static void ViewModel(Parametros param)
        {
            // GERAR ViewModel;
            DadosDaClasse.CriarAtributos(param, "");
            string template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathApplicationViewModelTemplate, @"ViewModel.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            template = template.Replace("{{Classe}}", param.NomeDaClasse);
            template = template.Replace("{{Atributos}}", param.Atributos);
            var nomeArquivo = $"{param.NomeDaClasse}ViewModel.cs";
            GravarResultado.Gravar(true, template, nomeArquivo, param.EnderecoDoProjetoApplication, @"ViewModels\");
        }

    }
}
