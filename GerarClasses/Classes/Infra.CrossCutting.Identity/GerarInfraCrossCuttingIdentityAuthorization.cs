namespace GerarClasses.Classes
{
    public static partial class GerarInfraCrossCuttingIdentity
    {
        private static readonly string pathIdentityAuthorizationTemplate = @"Templates\Infra.CrossCutting.Identity\Authorization\";

        public static void Authorization(Parametros param)
        {
            // GERAR ClaimRequirement;
            string template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathIdentityAuthorizationTemplate, @"ClaimRequirement.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            var nomeArquivo = "ClaimRequirement.cs";
            GravarResultado.Gravar(false, template, nomeArquivo, param.EnderecoDoProjetoInfraCrossCutingIdentity, @"Authorization\");

            // GERAR ClaimsRequirementHandler;
            template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathIdentityAuthorizationTemplate, @"ClaimsRequirementHandler.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            nomeArquivo = "ClaimsRequirementHandler.cs";
            GravarResultado.Gravar(false, template, nomeArquivo, param.EnderecoDoProjetoInfraCrossCutingIdentity, @"Authorization\");

        }

    }
}
