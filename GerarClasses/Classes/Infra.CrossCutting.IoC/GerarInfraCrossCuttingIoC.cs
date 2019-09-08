namespace GerarClasses.Classes
{
    public static partial class GerarInfraCrossCuttingIoC
    {
        private static readonly string pathInfraCrossCuttingIoCTemplate = @"Templates\Infra.CrossCutting.IoC\";

        public static void GerarProjeto(Parametros param, string prefixo1, string prefixo2, string prefixo3, string sufixo1, string sufixo2, string sufixo3)
        {
            // GERAR RegisterServices;
            string pfx1 = prefixo1 + param.NomeDaClasse;
            string pfx2 = prefixo2 + param.NomeDaClasse;
            string pfx3 = prefixo3 + param.NomeDaClasse;
            string sfx1 = param.NomeDaClasse + sufixo1;
            string sfx2 = param.NomeDaClasse + sufixo2;
            string sfx3 = param.NomeDaClasse + sufixo3;
            string template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathInfraCrossCuttingIoCTemplate, @"RegisterServices.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            template = template.Replace("{{Classe}}", param.NomeDaClasse);
            template = template.Replace("{{ClasseUpper}}", param.NomeDaClasse.ToUpper());
            template = template.Replace("{{Prefixo1Classe}}", pfx1);
            template = template.Replace("{{Prefixo2Classe}}", pfx2);
            template = template.Replace("{{Prefixo3Classe}}", pfx3);
            template = template.Replace("{{ClasseSufixo1}}", sfx1);
            template = template.Replace("{{ClasseSufixo2}}", sfx2);
            template = template.Replace("{{ClasseSufixo3}}", sfx3);

            var nomeArquivo = "RegisterServices.cs";
            GravarResultado.Gravar(false, template, nomeArquivo, param.EnderecoDoProjetoInfraCrossCutingIoc);

            // GERAR CROSSCUTTING IOC project;
            template = LerTemplate.Ler(param.EnderecoDaPastaPadraoDoProgramaGerador, pathInfraCrossCuttingIoCTemplate, @"CrossCuttingIoCCSPROJ.txt");
            template = template.Replace("{{Sistema}}", param.NomeDoSistema);
            nomeArquivo = $"{param.NomeDoSistema}.Infra.CrossCutting.IoC.csproj";
            GravarResultado.Gravar(false, template, nomeArquivo, param.EnderecoDoProjetoInfraCrossCutingIoc);

        }
    }
}
