namespace GerarClasses.Classes
{
    public static partial class GerarDomain
    {
        private static readonly string pathModelsTemplate = @"Templates\Domain\Models\";

        public static void Models(Parametros param)
        {
            DadosDaClasse.CriarConstrutor(param);
            DadosDaClasse.CriarAtributos(param, "private");
            string template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathModelsTemplate, @"Model.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            template = template.Replace("{{Classe}}", param.NomeDaClasse);
            template = template.Replace("{{Atributos}}", param.Atributos);
            template = template.Replace("{{ConstrutorDaClasse}}", param.Construtor);
            GravarResultado.Gravar(false, template, param.NomeDaClasse + ".cs", param.EnderecoDoProjetoDomain, @"Models\");
        }
    }
}
