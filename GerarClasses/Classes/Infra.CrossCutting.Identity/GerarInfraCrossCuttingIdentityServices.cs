namespace GerarClasses.Classes
{
    public static partial class GerarInfraCrossCuttingIdentity
    {
        private static readonly string pathIdentityServiceTemplate = @"Templates\Infra.CrossCutting.Identity\Services\";

        public static void Services(Parametros param)
        {
            // GERAR IEmailSender;
            string template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathIdentityServiceTemplate, @"IEmaiSender.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            var nomeArquivo = "IEmailSender.cs";
            GravarResultado.Gravar(false, template, nomeArquivo, param.EnderecoDoProjetoInfraCrossCutingIdentity, @"Services\");

            // GERAR ISMSSender;
            template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathIdentityServiceTemplate, @"ISmsSender.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            nomeArquivo = "ISmsSender.cs";
            GravarResultado.Gravar(false, template, nomeArquivo, param.EnderecoDoProjetoInfraCrossCutingIdentity, @"Services\");

            // GERAR MessageServices;
            template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathIdentityServiceTemplate, @"MessageService.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            nomeArquivo = "MessageServices.cs";
            GravarResultado.Gravar(false, template, nomeArquivo, param.EnderecoDoProjetoInfraCrossCutingIdentity, @"Services\");

        }

    }
}
