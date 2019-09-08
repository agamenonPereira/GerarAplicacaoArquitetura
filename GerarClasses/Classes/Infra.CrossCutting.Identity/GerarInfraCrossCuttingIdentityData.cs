namespace GerarClasses.Classes
{
    public static partial class GerarInfraCrossCuttingIdentity
    {
        private static readonly string pathIdentityDataTemplate = @"Templates\Infra.CrossCutting.Identity\Data\";

        public static void Data(Parametros param)
        {
            // GERAR ApplicationDbContext;
            string template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathIdentityDataTemplate, @"ApplicationDbContext.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            var nomeArquivo = "ApplicationDbContext.cs";
            GravarResultado.Gravar(false, template, nomeArquivo, param.EnderecoDoProjetoInfraCrossCutingIdentity, @"Data\");

        }

    }
}
