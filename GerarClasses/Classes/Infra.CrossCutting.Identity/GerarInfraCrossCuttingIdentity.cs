namespace GerarClasses.Classes
{
    public static partial class GerarInfraCrossCuttingIdentity
    {
        private static readonly string pathInfraIdentityProjectTemplate = @"Templates\Infra.CrossCutting.Identity\csproj\";

        public static void GerarProjeto(Parametros param)
        {
            // GERAR DOMAIN PROJECT;
            string template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathInfraIdentityProjectTemplate, @"Infra.Identity.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            var nomeArquivo = $"{param.NomeDoSistema}.Infra.CrossCutting.Identity.csproj";
            GravarResultado.Gravar(false, template, nomeArquivo, param.EnderecoDoProjetoInfraCrossCutingIdentity);
        }
    }
}
