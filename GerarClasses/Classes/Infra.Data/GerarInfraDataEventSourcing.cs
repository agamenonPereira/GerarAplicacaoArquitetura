namespace GerarClasses.Classes
{
    public static partial class GerarInfraData
    {
        private static readonly string pathEventSourcingTemplate = @"Templates\Infra.Data\EventSourcing\";

        public static void EventSourcing(Parametros param)
        {
            // GERAR EventSourcing;
            string template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathEventSourcingTemplate, @"SqlEventStore.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            var nomeArquivo = "SqlEventStore.cs";
            GravarResultado.Gravar(true, template, nomeArquivo, param.EnderecoDoProjetoInfraData, @"EventSourcing\");
        }

    }
}
