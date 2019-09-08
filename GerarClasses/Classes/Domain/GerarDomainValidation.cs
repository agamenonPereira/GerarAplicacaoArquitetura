using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GerarClasses.Classes
{
    public static partial class GerarDomain
    {
        private static readonly string pathValidationTemplate = @"Templates\Domain\Validation\";

        public static void Validation(Parametros param, string prefixo1, string prefixo2, string prefixo3)
        {
            // GERAR ClasseValidation;
            string template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathValidationTemplate, @"ClasseValidation.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            template = template.Replace("{{Classe}}", param.NomeDaClasse);
            StringBuilder sbGeral = new StringBuilder();
            foreach (var item in param.ListaDeAtributos)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"        protected void Validar{item.Nome}()                         ");
                sb.AppendLine( "        {                                                           ");
                sb.AppendLine($"            RuleFor(c => c.{item.Nome})                             ");
                sb.AppendLine( "               .NotEmpty()                                          ");
                sb.AppendLine( "               .NotNull()                                           ");
                sb.AppendLine($"               .WithMessage(\"{item.Nome} deve ser informado(a)\"); ");
                sb.AppendLine( "        }                                                           ");
                sb.AppendLine( "                                                                    ");
                sbGeral.AppendLine(sb.ToString());
            }
            template = template.Replace("{{Validacoes}}", sbGeral.ToString());
            var nomeArquivo = $"{param.NomeDaClasse}Validation.cs";
            GravarResultado.Gravar(true, template, nomeArquivo, param.EnderecoDoProjetoDomain, @"Validations\");

            // GERAR ClasseCommandValidation;
            StringBuilder sbMetodos = new StringBuilder();
            foreach (var item in param.ListaDeAtributos)
            {
                sbMetodos.AppendLine($"            Validar{item.Nome}();                         ");
            }
            // Gerar Para o Prefixo1;
            template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathValidationTemplate, @"ClasseCommandValidation.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            template = template.Replace("{{Classe}}", param.NomeDaClasse);
            template = template.Replace("{{PrefixoClasse}}", prefixo1);
            template = template.Replace("{{MetodosValidacao}}", sbMetodos.ToString());
            nomeArquivo = $"{prefixo1}{param.NomeDaClasse}CommandValidation.cs";
            GravarResultado.Gravar(true, template, nomeArquivo, param.EnderecoDoProjetoDomain, @"Validations\");

            // Gerar Para o Prefixo2;
            template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathValidationTemplate, @"ClasseCommandValidation.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            template = template.Replace("{{Classe}}", param.NomeDaClasse);
            template = template.Replace("{{PrefixoClasse}}", prefixo2);
            template = template.Replace("{{MetodosValidacao}}", sbMetodos.ToString());
            nomeArquivo = $"{prefixo2}{param.NomeDaClasse}CommandValidation.cs";
            GravarResultado.Gravar(true, template, nomeArquivo, param.EnderecoDoProjetoDomain, @"Validations\");

            // Gerar Para o Prefixo3;
            template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathValidationTemplate, @"ClasseCommandValidation.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            template = template.Replace("{{Classe}}", param.NomeDaClasse);
            template = template.Replace("{{PrefixoClasse}}", prefixo3);
            template = template.Replace("{{MetodosValidacao}}", sbMetodos.ToString());
            nomeArquivo = $"{prefixo3}{param.NomeDaClasse}CommandValidation.cs";
            GravarResultado.Gravar(true, template, nomeArquivo, param.EnderecoDoProjetoDomain, @"Validations\");

        }

    }
}
