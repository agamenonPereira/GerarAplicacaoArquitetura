using GerarClasses.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerarClasses
{
    public class Parametros
    {
        public string NomeDoSistema;
        public string NomeDaClasse;
        public string EnderecoDaPastaDoSistemaRaiz;
        public string EnderecoDaPastaDoSistemaSrc;
        public string EnderecoDoProjetoDomain;
        public string EnderecoDoProjetoDomainCore;
        public string EnderecoDoProjetoApplication;
        public string EnderecoDoProjetoInfraData;
        public string EnderecoDoProjetoInfraCrossCutingBus;
        public string EnderecoDoProjetoInfraCrossCutingIdentity;
        public string EnderecoDoProjetoInfraCrossCutingIoc;
        public string EnderecoDoProjetoWebApi;
        public string EnderecoDoProjetoUI;
        public string EnderecoDaPastaPadraoDoProgramaGerador;

        public List<Atributos> ListaDeAtributos;
        public string Construtor;
        public string Atributos;
    }
}
