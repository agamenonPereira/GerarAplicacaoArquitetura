using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GerarClasses.Classes
{
    public static partial class GerarApplication
    {
        private static readonly string pathApplicationAutoMapperTemplate = @"Templates\Application\AutoMapper\";

        public static void AutoMapper(Parametros param, string prefixo1Command, string prefixo2Command, string prefixo3Command)
        {
            // GERAR AutoMapper (ViewModelToDomain);
            var listaConstrutorDaClasseComPrefixo = DadosDaClasse.ListaDeAtributosParaConstrutor(param, "c", false);
            string template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathApplicationAutoMapperTemplate, @"ViewModelToDomain.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            template = template.Replace("{{Classe}}", param.NomeDaClasse);
            template = template.Replace("{{Prefixo1Classe}}", prefixo1Command + param.NomeDaClasse);
            template = template.Replace("{{Prefixo2Classe}}", prefixo2Command + param.NomeDaClasse);
            template = template.Replace("{{Prefixo3Classe}}", prefixo3Command + param.NomeDaClasse);
            template = template.Replace("{{ConstrutorDaClasseComPrefixo}}", listaConstrutorDaClasseComPrefixo);
            var nomeArquivo = $"ViewModelToDomain{param.NomeDaClasse}.cs";
            GravarResultado.Gravar(true, template, nomeArquivo, param.EnderecoDoProjetoApplication, @"AutoMapper\");

            // GERAR AutoMapper (DomainToViewModel);
            template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathApplicationAutoMapperTemplate, @"DomainToViewModel.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            template = template.Replace("{{Classe}}", param.NomeDaClasse);
            nomeArquivo = $"DomainToViewModel{param.NomeDaClasse}.cs";
            GravarResultado.Gravar(true, template, nomeArquivo, param.EnderecoDoProjetoApplication, @"AutoMapper\");
        }

    }
}
