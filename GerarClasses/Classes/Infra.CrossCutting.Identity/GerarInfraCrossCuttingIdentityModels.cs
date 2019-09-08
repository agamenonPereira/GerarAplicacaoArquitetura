namespace GerarClasses.Classes
{
    public static partial class GerarInfraCrossCuttingIdentity
    {
        private static readonly string pathIdentityModelsTemplate = @"Templates\Infra.CrossCutting.Identity\Models\";

        public static void Models(Parametros param)
        {
            // GERAR ApplicationUsers;
            string template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathIdentityModelsTemplate, @"ApplicationUser.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            var nomeArquivo = "ApplicationUser.cs";
            GravarResultado.Gravar(false, template, nomeArquivo, param.EnderecoDoProjetoInfraCrossCutingIdentity, @"Models\");

            // GERAR AspNetUsers;
            template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathIdentityModelsTemplate, @"AspNetUser.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            nomeArquivo = "AspNetUser.cs";
            GravarResultado.Gravar(false, template, nomeArquivo, param.EnderecoDoProjetoInfraCrossCutingIdentity, @"Models\");

        }

    }
}
