using System.IO;

namespace GerarClasses.Classes
{
    public static class DadosDoSistema
    {
        // cria as pastas de todos os projetos vinculados;
        public static void CriarProjetosPadrao(Parametros parm)
        {
            Criar(parm.EnderecoDaPastaDoSistemaSrc);

            // CRIAR PROJETO Domain;
            var domain = $@"{parm.EnderecoDaPastaDoSistemaSrc}{parm.NomeDoSistema}.Domain\";
            Criar(domain);
            parm.EnderecoDoProjetoDomain = domain;

            // CRIAR PROJETO DomainCore;
            var domainCore = $@"{parm.EnderecoDaPastaDoSistemaSrc}{parm.NomeDoSistema}.Domain.Core\";
            Criar(domainCore);
            parm.EnderecoDoProjetoDomainCore = domainCore;

            // CRIAR PROJETO Application;
            var application = $@"{parm.EnderecoDaPastaDoSistemaSrc}{parm.NomeDoSistema}.Application\";
            Criar(application);
            parm.EnderecoDoProjetoApplication = application;

            // CRIAR PROJETO Infra.CrossCutting.Bus;
            var infraCrossBus = $@"{parm.EnderecoDaPastaDoSistemaSrc}{parm.NomeDoSistema}.Infra.CrossCutting.Bus\";
            Criar(infraCrossBus);
            parm.EnderecoDoProjetoInfraCrossCutingBus = infraCrossBus;

            // CRIAR PROJETO Infra.CrossCutting.Identity;
            var infraCrossIdentity = $@"{parm.EnderecoDaPastaDoSistemaSrc}{parm.NomeDoSistema}.Infra.CrossCutting.Identity\";
            Criar(infraCrossIdentity);
            parm.EnderecoDoProjetoInfraCrossCutingIdentity = infraCrossIdentity;

            // CRIAR PROJETO Infra.CrossCutting.Identity;
            var infraCrossIoc = $@"{parm.EnderecoDaPastaDoSistemaSrc}{parm.NomeDoSistema}.Infra.CrossCutting.IoC\";
            Criar(infraCrossIoc);
            parm.EnderecoDoProjetoInfraCrossCutingIoc = infraCrossIoc;

            // CRIAR PROJETO infra.Data;
            var infraData = $@"{parm.EnderecoDaPastaDoSistemaSrc}{parm.NomeDoSistema}.Infra.Data\";
            Criar(infraData);
            parm.EnderecoDoProjetoInfraData = infraData;

            // CRIAR PROJETO WebApi;
            var webApi = $@"{parm.EnderecoDaPastaDoSistemaSrc}{parm.NomeDoSistema}.WebApi\";
            Criar(webApi);
            parm.EnderecoDoProjetoWebApi = webApi;

            // CRIAR PROJETO WebApi;
            var ui = $@"{parm.EnderecoDaPastaDoSistemaSrc}{parm.NomeDoSistema}.MVC\";
            Criar(ui);
            parm.EnderecoDoProjetoUI = ui;
        }


        private static void Criar(string path)
        {
            if (!Directory.Exists(Path.Combine(path)))
            {
                Directory.CreateDirectory(Path.Combine(path));
            }
        }

    }
}
