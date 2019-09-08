namespace GerarClasses.Classes
{
    public static partial class GerarInfraCrossCuttingIdentity
    {
        private static readonly string pathIdentityExtensionsTemplate = @"Templates\Infra.CrossCutting.Identity\Extensions\";

        public static void Extensions(Parametros param)
        {
            // GERAR ClaimsExtensions;
            string template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathIdentityExtensionsTemplate, @"ClaimsExtensions.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            var nomeArquivo = "ClaimsExtensions.cs";
            GravarResultado.Gravar(false, template, nomeArquivo, param.EnderecoDoProjetoInfraCrossCutingIdentity, @"Extensions\");

            // GERAR EmailSenderExtensions;
            template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathIdentityExtensionsTemplate, @"EmailSenderExtensions.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            nomeArquivo = "EmailSenderExtensions.cs";
            GravarResultado.Gravar(false, template, nomeArquivo, param.EnderecoDoProjetoInfraCrossCutingIdentity, @"Extensions\");

        }

    }
}
