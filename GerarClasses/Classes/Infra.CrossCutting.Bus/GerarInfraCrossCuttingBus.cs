namespace GerarClasses.Classes
{
    public static partial class GerarInfraCrossCuttingBus
    {
        private static readonly string pathInfraCrossCuttingBusTemplate = @"Templates\Infra.CrossCutting.Bus\";

        public static void GerarProjeto(Parametros param)
        {
            // GERAR in memory bus;
            string template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathInfraCrossCuttingBusTemplate, @"InMemoryBus.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            var nomeArquivo = "InMemoryBus.cs";
            GravarResultado.Gravar(false, template, nomeArquivo, param.EnderecoDoProjetoInfraCrossCutingBus);

            // GERAR CROSSCUTTING project;
            template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathInfraCrossCuttingBusTemplate, @"CrossCuttingBusCSPROJ.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            nomeArquivo = $"{param.NomeDoSistema}.Infra.CrossCutting.Bus.csproj";
            GravarResultado.Gravar(false, template, nomeArquivo, param.EnderecoDoProjetoInfraCrossCutingBus);

        }
    }
}
