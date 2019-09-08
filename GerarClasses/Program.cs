using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using GerarClasses.Classes;
using ObjetosVinculados;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GerarClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            // definir os dados da pasta padrão da aplicação onde serão lidos os templates e o nome da classe;
            var pastaPadrao = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            var pastas = pastaPadrao.Split(@"\");
            if (pastas.Length > 3)
            {
                var excl = pastas[pastas.Length - 3] + @"\" + pastas[pastas.Length - 2] + @"\" + pastas[pastas.Length - 1];
                pastaPadrao = pastaPadrao.Replace(excl, "");
            }
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] tp = assembly.GetTypes();
            Type classeDefinida = null;
            foreach (var item in tp)
            {
                if (item.Namespace.ToUpper() == "CLASSEDEFINIDA")
                {
                    classeDefinida = item;
                    break;
                }
            }

            if (classeDefinida == null)
            {
                Console.WriteLine("Não foi encontrada a Classe Definida - Verifique");
                return;
            }
            if (classeDefinida.GetProperties().Length < 1)
            {
                Console.WriteLine("Tem classe definida, mas não tem propriedades - Verifique");
                return;
            }
            string nomeDaClasse = classeDefinida.Name;

            //----------------------------------------------------------------------------------------------------
            // DADOS A SEREM INFORMADOS
            //----------------------------------------------------------------------------------------------------
            string nomeDoSistema = "ASPSecurity";

            var prefixo1 = "Incluir";
            var prefixo2 = "Alterar";
            var prefixo3 = "Excluir";
            var sufixo1 = "Incluido";
            var sufixo2 = "Alterado";
            var sufixo3 = "Excluido";
            // este nome pode ser (masculino ou feminino. EX: ObterTodo, ObterTodos, ObterToda, ObterTodas);
            var nomeDoMetodoObterTodos = "ObterTodo";

            Parametros parm = new Parametros();
            parm.NomeDaClasse = nomeDaClasse;

            parm.NomeDoSistema = nomeDoSistema;
            parm.EnderecoDaPastaDoSistemaRaiz = $@"C:\SistemaGerado\{nomeDoSistema}\";
            parm.EnderecoDaPastaDoSistemaSrc = $@"C:\SistemaGerado\{nomeDoSistema}\src\";
            parm.EnderecoDaPastaPadraoDoProgramaGerador = pastaPadrao;
            DadosDoSistema.CriarProjetosPadrao(parm);

            parm.ListaDeAtributos = new List<Atributos>();
            foreach (var x in classeDefinida.GetProperties())
            {
                string nome = x.Name;
                if (nome.Length > 1)
                    nome = char.ToUpper(nome[0]) + nome.Substring(1);
                var atributo = x.PropertyType.Name;
                if (atributo.ToUpper().Contains("NULLABLE"))
                    atributo = AjustarNullable(x.PropertyType.FullName);
                string tipo = Util.AtualizarTipo(atributo);
                parm.ListaDeAtributos.Add(new Atributos { Nome = nome, Tipo = tipo });
            }

            DadosDaClasse.CriarConstrutor(parm);

            // GERAR CLASSES DO DOMINIO;

            GerarDomainCore.DomainCore(parm);
            GerarDomain.Models(parm);
            GerarDomain.Interfaces(parm, nomeDoMetodoObterTodos);
            GerarDomain.Events(parm, sufixo1);
            GerarDomain.Events(parm, sufixo2);
            GerarDomain.Events(parm, sufixo3);
            GerarDomain.EventHandler(parm, sufixo1, sufixo2, sufixo3);
            GerarDomain.Commands(parm, prefixo1);
            GerarDomain.Commands(parm, prefixo2);
            GerarDomain.Commands(parm, prefixo3);
            GerarDomain.CommandHandler(parm, prefixo1, prefixo2, prefixo3, sufixo1, sufixo2, sufixo3);
            GerarDomain.Validation(parm, prefixo1, prefixo2, prefixo3);
            GerarDomain.GerarProjeto(parm);

            // GERAR CLASSES DO INFRA.DATA;
            GerarInfraData.Repositories(parm, nomeDoMetodoObterTodos);
            GerarInfraData.UoW(parm);
            GerarInfraData.Mappings(parm);
            GerarInfraData.EventSourcing(parm);
            GerarInfraData.Context(parm);
            GerarInfraData.GerarProjeto(parm);

            // GERAR CLASSES DO APPLICATION;
            GerarApplication.ViewModel(parm);
            GerarApplication.IService(parm, nomeDoMetodoObterTodos);
            GerarApplication.Service(parm, nomeDoMetodoObterTodos);
            GerarApplication.AutoMapper(parm, prefixo1, prefixo2, prefixo3);
            GerarApplication.GerarProjeto(parm);

            // GERAR CLASSES DO CROSCUTTING BUS;
            GerarInfraCrossCuttingBus.GerarProjeto(parm);

            // GERAR CLASSES DO CROSCUTTING IOC;
            GerarInfraCrossCuttingIoC.GerarProjeto(parm, prefixo1, prefixo2, prefixo3, sufixo1, sufixo2, sufixo3);

            // GERAR CLASSES DO CROSCUTTING IDENTITY;
            GerarInfraCrossCuttingIdentity.Authorization(parm);
            GerarInfraCrossCuttingIdentity.Data(parm);
            GerarInfraCrossCuttingIdentity.Models(parm);
            GerarInfraCrossCuttingIdentity.Services(parm);
            GerarInfraCrossCuttingIdentity.Extensions(parm);
            GerarInfraCrossCuttingIdentity.GerarProjeto(parm);

            // GERAR SOLUTION;
            GerarSolution.GerarProjeto(parm);

            // FIM DA GERAÇÃO;
            Console.WriteLine($"FIM DA GERAÇÃO DA CLASSE {parm.NomeDaClasse} .... TECLE ALGO PARA FINALIZAR");
            Console.ReadKey();
        }


        private static string AjustarNullable(string nome)
        {
            string pattern = @"\bSystem.\w*\b,";
            Match m = Regex.Match(nome, pattern, RegexOptions.IgnoreCase);
            string res = m.Value;
            res = res.Replace("System.", "");
            res = res.Replace(",", "");
            res = Util.AtualizarTipo(res);
            res = res + "?";
            return res;
        }

    }
}



//----------------------------------------------------------------------------------------------------
// DADOS A SEREM INFORMADOS
// DIGITE AQUI A CLASSE QUE SERÁ PROCESSADA;
//----------------------------------------------------------------------------------------------------
namespace ClasseDefinida
{
    class Programa
    {
        public int CodigoId { get; set; }
        public string Descricao { get; set; }
        public string URLAction { get; set; }
        public string URLController { get; set; }
        public int CodigoVinculadoId { get; set; }
        public Sistema Sistema { get; set; }
        public int? Nivel { get; set; }
        public int Ordem { get; set; }
        public string Icone { get; set; }
        public string Situacao { get; set; }
    }
}

//----------------------------------------------------------------------------------------------------
// DADOS A SEREM INFORMADOS
// CRIE AQUI OS OBJETOS VINCULADOS PARA NÃO DAR ERRO NA CLASSE
//----------------------------------------------------------------------------------------------------
namespace ObjetosVinculados
{
    public class Sistema 
    {
    }





}


