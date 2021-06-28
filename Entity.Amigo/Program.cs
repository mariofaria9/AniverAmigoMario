using System;
using System.Collections.Generic;
using System.Globalization;
using Entity.Domain;
using Entity.Repositorio;

namespace Entity.Amigo
{
    public class Program
    {
        public static Repositorio.IAmigoRepositorio amigoRepositorio = new Repositorio.AmigoRepositorio();

        public static void Main(string[] args)
        {
            Console.WriteLine("");
            Console.WriteLine("++++++++++++++  GERENCIADOR  ++++++++++++++++++");
            Console.WriteLine("++++++++++++++  ANIVERSARIO  +++++++++++++++++++");
            Console.WriteLine("++++++++++++  AMIGOS DO MARIO  +++++++++++++++++");
            Console.WriteLine("");

            Console.Write("Olá!! Hoje é dia:  ");
            Console.Write(DateTime.Now);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("            ANIVERSARIANTES DO DIA!!! ");
            Console.WriteLine("                PARABÉNS PARA: ");
            Console.WriteLine("");
            CultureInfo culture = new CultureInfo("pt-BR");
            foreach (Domain.Amigo am in amigoRepositorio.AniversariantesDoDiaDB())
            {
                Console.WriteLine("Nome: {0} {1}", am.Nome, am.Sobrenome);
                Console.WriteLine("");
            }
            Console.WriteLine("");
            Console.WriteLine("");


            var sair_do_prog = false;
            while (!sair_do_prog)
            {
                Menu();
                string selecao = Console.ReadLine();

                switch (selecao)
                {
                    case "1":
                        ObterAmigo();
                        break;
                    case "2":
                        CadastrarAmigo();
                        break;
                    case "3":
                        AtualizarAmigo();
                        break;
                    case "4":
                        ExcluirAmigo();
                        break;
                    case "5":
                        ListarAmigos();
                        break;
                    case "6":
                        Console.WriteLine("");
                        Console.WriteLine("++++++ Obrigado por usar o programa de Gerenciador de Niver do Mario! Até breve! ++++++");
                        Console.WriteLine("");
                        sair_do_prog = true;
                        break;
                    default:
                        Console.WriteLine("");
                        Console.WriteLine("Esta opcao nao existe, por favor entre com uma opcao valida!");
                        Console.WriteLine("");
                        break;
                }
            }
        }

        public static void Menu()
        {
            Console.WriteLine("");
            Console.WriteLine("Selecione um numero no Menu abaixo para realizar a ação.");
            Console.WriteLine("1 - Para encontrar um amigo.");
            Console.WriteLine("2 - Para cadastrar um amigo.");
            Console.WriteLine("3 - Para atualizar um amigo.");
            Console.WriteLine("4 - Para excluir um amigo.");
            Console.WriteLine("5 - Listar todos os amigos.");
            Console.WriteLine("6 - Para sair do programa.");
            Console.WriteLine("");
        }

        public static void ListarAmigos()
        {
            CultureInfo culture = new CultureInfo("pt-BR");
            Console.WriteLine("");
            Console.WriteLine("LISTA DE AMIGOS:");
            Console.WriteLine("");
            foreach (Domain.Amigo am in amigoRepositorio.PegarTodosDB())
            {
                Console.WriteLine("Id: {0}", am.Id);
                Console.WriteLine("Nome: {0}", am.Nome);
                Console.WriteLine("Sobrenome: {0}", am.Sobrenome);
                Console.WriteLine("Data de Nascimento: {0}", am.DataNascimento.ToString("d", culture));
                Console.WriteLine("");
                Console.WriteLine("Faltam {0} dias para este aniversario!", am.CalcularTempo());
                Console.WriteLine("");
            }
            Console.WriteLine("");
            Console.WriteLine("");

        }

        private static void ExcluirAmigo()
        {
            Console.WriteLine("");
            Console.WriteLine("Digite o identificador do amigo que quer remover.");
            int identificador = Convert.ToInt32(Console.ReadLine().ToUpper());
            Console.WriteLine("");

            amigoRepositorio.DeletarDB(identificador);

            Console.WriteLine("Amigo excluído com sucesso!");
        }

        private static void AtualizarAmigo()
        {
            Console.WriteLine("");
            Console.WriteLine("Digite o identificador do amigo que quer atualizar.");
            int id = Convert.ToInt32(Console.ReadLine().ToUpper());
            var ami = amigoRepositorio.GetAmigoDB(id);

            Console.WriteLine("");

            Console.WriteLine("Entre com o nome do amigo:");
            ami.Nome = Console.ReadLine().ToUpper();
            Console.WriteLine("Entre com o sobrenome do amigo:");
            ami.Sobrenome = Console.ReadLine().ToUpper();
            Console.WriteLine("Entre com a data de nascimento do amigo no formato DD/MM/YYYY:");
            ami.DataNascimento = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("");

            amigoRepositorio.AtualizarDB(ami, id);

            Console.WriteLine("");
            Console.WriteLine("Dados atualizados com sucesso!");
        }

        private static void CadastrarAmigo()
        {
            Domain.Amigo amigo = new Domain.Amigo();
            Console.WriteLine("Entre com o nome do amigo:");
            var nome = Console.ReadLine().ToUpper();
            Console.WriteLine("Entre com o sobrenome do amigo:");
            var sobrenome = Console.ReadLine().ToUpper();
            Console.WriteLine("Entre com a data de nascimento do amigo no formato DD/MM/YYYY:");
            DateTime Dob = DateTime.Parse(Console.ReadLine());

            amigo.Nome = nome;
            amigo.Sobrenome = sobrenome;
            amigo.DataNascimento = Dob;

            Console.WriteLine("");
            Console.WriteLine("Os dados abaixo estao corretos?");
            Console.WriteLine("");

            CultureInfo culture = new CultureInfo("pt-BR");
            Console.WriteLine("Nome: {0}", nome);
            Console.WriteLine("Sobrenome: {0}", sobrenome);
            Console.WriteLine("Data de Nascimento: {0}", Dob.ToString("d", culture));
            Console.WriteLine("");
            Console.WriteLine("1 - Sim");
            Console.WriteLine("2 - Nao");
            Console.WriteLine("");
            var num = Console.ReadLine();

            if (num == "1")
            {
                amigoRepositorio.CadastrarDB(amigo);
                Console.WriteLine("Amigo cadastrado com sucesso!");
            }
            else if (num == "2")
            {
                CadastrarAmigo();
            }
        }

        private static void ObterAmigo()
        {
            CultureInfo culture = new CultureInfo("pt-BR");
            Console.WriteLine("");
            Console.WriteLine("Digite o nome ou parte do nome do amigo.");

            string nome = Console.ReadLine().ToUpper();
            Console.WriteLine("");

            var ami = amigoRepositorio.GetAmigoNomeDB(nome);


            foreach (var am in ami)
            {
                Console.WriteLine("Exibindo Dados do amigo:");
                Console.WriteLine("");
                Console.WriteLine("Id: {0}", am.Id);
                Console.WriteLine($"Nome Completo: {am.Nome} { am.Sobrenome}");
                Console.WriteLine("Data de Nascimento: {0}", am.DataNascimento.ToString("d", culture));
                Console.WriteLine("");
                Console.WriteLine("Faltam {0} dias para este aniversario!", am.CalcularTempo());
                Console.WriteLine("");
            }
        }
    }
}
