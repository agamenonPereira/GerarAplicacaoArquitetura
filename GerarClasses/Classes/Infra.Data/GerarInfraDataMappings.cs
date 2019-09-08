namespace GerarClasses.Classes
{
    public static partial class GerarInfraData
    {
        private static readonly string pathMappingsTemplate = @"Templates\Infra.Data\Mappings\";

        public static void Mappings(Parametros param)
        {
            // GERAR Mappings;
            string template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathMappingsTemplate, @"StoredEventMap.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            var nomeArquivo = "StoredEventMap.cs";
            GravarResultado.Gravar(true, template, nomeArquivo, param.EnderecoDoProjetoInfraData, @"Mappings\");
        }

    }
}
