namespace GerarClasses.Classes
{
    public static partial class GerarInfraData
    {
        private static readonly string pathUoWTemplate = @"Templates\Infra.Data\UoW\";

        public static void UoW(Parametros param)
        {
            // GERAR Repository (Generico);
            string template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathUoWTemplate, @"UnitOfWork.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            var nomeArquivo = "UnitOfWork.cs";
            GravarResultado.Gravar(true, template, nomeArquivo, param.EnderecoDoProjetoInfraData, @"UoW\");
        }

    }
}
