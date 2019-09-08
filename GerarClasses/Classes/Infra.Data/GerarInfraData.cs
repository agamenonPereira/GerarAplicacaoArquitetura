namespace GerarClasses.Classes
{
    public static partial class GerarInfraData
    {
        private static readonly string pathInfraDataProjectTemplate = @"Templates\Infra.Data\csproj\";

        public static void GerarProjeto(Parametros param)
        {
            // GERAR DOMAIN PROJECT;
            string template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathInfraDataProjectTemplate, @"Infra.Data.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            var nomeArquivo = $"{param.NomeDoSistema}.Infra.Data.csproj";
            GravarResultado.Gravar(false, template, nomeArquivo, param.EnderecoDoProjetoInfraData);
        }
    }
}
