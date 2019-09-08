namespace GerarClasses.Classes
{
    public static partial class GerarApplication
    {
        private static readonly string pathApplicationProjectTemplate = @"Templates\Application\CSPROJ\";

        public static void GerarProjeto(Parametros param)
        {
            // GERAR DOMAIN PROJECT;
            string template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathApplicationProjectTemplate, @"csproj.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            var nomeArquivo = $"{param.NomeDoSistema}.Application.csproj";
            GravarResultado.Gravar(false, template, nomeArquivo, param.EnderecoDoProjetoApplication);
        }

    }
}
