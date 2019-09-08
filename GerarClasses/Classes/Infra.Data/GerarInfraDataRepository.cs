namespace GerarClasses.Classes
{
    public static partial class GerarInfraData
    {
        private static readonly string pathRepositoriesTemplate = @"Templates\Infra.Data\Repositories\";

        public static void Repositories(Parametros param, string nomeDoMetodoObterTodos)
        {
            // GERAR Repository (Generico);
            string template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathRepositoriesTemplate, @"Repository.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            var nomeArquivo = "Repository.cs";
            GravarResultado.Gravar(true, template, nomeArquivo, param.EnderecoDoProjetoInfraData, @"Repositories\");

            // GERAR ClasseRepository;
            template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathRepositoriesTemplate, @"ClasseRepository.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            template = template.Replace("{{Classe}}", param.NomeDaClasse);
            template = template.Replace("{{NomeDoMetodoObterTodos}}", nomeDoMetodoObterTodos);
            var atributo = param.ListaDeAtributos.Count > 0 ? param.ListaDeAtributos[0] : null;
            if (atributo != null)
            {
                string primeiroAtributoComTipo = $"{atributo.Tipo} {atributo.Nome.ToLower()}"; 
                template = template.Replace("{{PrimeiroAtributoComTipo}}", primeiroAtributoComTipo);
                template = template.Replace("{{PrimeiroAtributo}}", atributo.Nome);
                template = template.Replace("{{PrimeiroAtributoLowerCase}}", atributo.Nome.ToLower());
            }
            nomeArquivo = $"{param.NomeDaClasse}Repository.cs";
            GravarResultado.Gravar(true, template, nomeArquivo, param.EnderecoDoProjetoInfraData, @"Repositories\");

            // GERAR EventStoreSQLRepository;
            template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathRepositoriesTemplate, @"EventSourcing\EventStoreSQLRepository.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            nomeArquivo = "EventStoreSQLRepository.cs";
            GravarResultado.Gravar(true, template, nomeArquivo, param.EnderecoDoProjetoInfraData, @"Repositories\EventSourcing\");

            // GERAR IEventStoreRepository;
            template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathRepositoriesTemplate, @"EventSourcing\IEventStoreRepository.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            nomeArquivo = "IEventStoreRepository.cs";
            GravarResultado.Gravar(true, template, nomeArquivo, param.EnderecoDoProjetoInfraData, @"Repositories\EventSourcing\");

        }

    }
}
