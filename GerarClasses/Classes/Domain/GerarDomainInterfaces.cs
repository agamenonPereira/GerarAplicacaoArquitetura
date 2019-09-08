namespace GerarClasses.Classes
{
    public static partial class GerarDomain
    {
        private static readonly string pathInterfaceTemplate = @"Templates\Domain\Interfaces\";

        public static void Interfaces(Parametros param, string nomeDoMetodoObterTodos)
        {
            // GERAR IRepository;
            string template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathInterfaceTemplate, @"IRepository.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            GravarResultado.Gravar(true, template, "IRepository.cs", param.EnderecoDoProjetoDomain, @"Interfaces\");

            // GERAR IUnitOfWork;
            template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathInterfaceTemplate, @"IUnitOfWork.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            GravarResultado.Gravar(true, template, "IUnitOfWork.cs", param.EnderecoDoProjetoDomain, @"Interfaces\");

            // GERAR IClasseRepository;
            template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathInterfaceTemplate, @"IClasseRepository.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            template = template.Replace("{{Classe}}", param.NomeDaClasse);
            template = template.Replace("{{NomeDoMetodoObterTodos}}", nomeDoMetodoObterTodos);
            var atributo = param.ListaDeAtributos.Count > 0 ? param.ListaDeAtributos[0] : null;
            if (atributo != null)
            {
                string primeiroAtributoComTipo = $"{atributo.Tipo} {atributo.Nome.ToLower()}";
                template = template.Replace("{{PrimeiroAtributoComTipo}}", primeiroAtributoComTipo);
            }
            string nomeArquivo = $"I{param.NomeDaClasse}Repository.cs";
            GravarResultado.Gravar(true, template, nomeArquivo, param.EnderecoDoProjetoDomain, @"Interfaces\");

            // GERAR IUser;
            template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathInterfaceTemplate, @"IUser.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            nomeArquivo = $"IUser.cs";
            GravarResultado.Gravar(true, template, nomeArquivo, param.EnderecoDoProjetoDomain, @"Interfaces\");

        }

    }
}
