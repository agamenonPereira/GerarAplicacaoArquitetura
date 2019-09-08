namespace GerarClasses.Classes
{
    public static partial class GerarInfraData
    {
        private static readonly string pathContextTemplate = @"Templates\Infra.Data\Context\";

        public static void Context(Parametros param)
        {
            // GERAR EventStoreSQL;
            string template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathContextTemplate, @"EventStoreSQLContext.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            var nomeArquivo = "EventStoreSQLContext.cs";
            GravarResultado.Gravar(true, template, nomeArquivo, param.EnderecoDoProjetoInfraData, @"Context\");

            // GERAR Context;
            template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathContextTemplate, @"Context.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            template = template.Replace("{{Classe}}", param.NomeDaClasse);
            nomeArquivo = $"{param.NomeDoSistema}Context.cs";
            GravarResultado.Gravar(true, template, nomeArquivo, param.EnderecoDoProjetoInfraData, @"Context\");


        }

    }
}
