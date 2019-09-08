namespace GerarClasses.Classes
{
    public static partial class GerarDomain
    {

        private static readonly string pathDomainProjectTemplate = @"Templates\Domain\CSPROJ\";

        public static void GerarProjeto(Parametros param)
        {
            // GERAR DOMAIN PROJECT;
            string template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathDomainProjectTemplate, @"csproj.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            var nomeArquivo = $"{param.NomeDoSistema}.Domain.csproj";
            GravarResultado.Gravar(false, template, nomeArquivo, param.EnderecoDoProjetoDomain);
        }
    }
}
