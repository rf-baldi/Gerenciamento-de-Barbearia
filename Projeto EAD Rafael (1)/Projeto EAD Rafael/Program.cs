using System;
using System.Collections.Generic;
using System.IO;

namespace Barbearia;
    class Program
    {
        static List<Cliente> clientes = new List<Cliente>(); 
        static List<Barbeiro> barbeiros = new List<Barbeiro>();
        static double lucroTotal = 0;

        static void Main(string[] args)
        {
            CarregarDados();
            Menu menu = new Menu();
            int opcao;

            do
            {
                opcao = menu.MostrarMenu();
                ExecutarOpcao(opcao);
            } while (opcao != 0);

            SalvarDados();
        }

        static void ExecutarOpcao(int opcao)
        {
            switch (opcao)
            {
                case 1:
                    CriarCliente();
                    break;
                case 2:
                    CriarBarbeiro();
                    break;
                case 3:
                    RegistrarCorte();
                    break;
                case 4:
                    MostrarRelatorio();
                    break;
                case 0:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }

        static void CriarCliente()
        {
            Console.Write("Nome do Cliente: ");
            string nome = Console.ReadLine();
            Console.Write("Idade: ");
            int idade = Convert.ToInt32(Console.ReadLine());
            Console.Write("CPF: ");
            string cpf = Console.ReadLine();
            Console.Write("Barbeiro Favorito: ");
            string barbeiroFavorito = Console.ReadLine();

            Cliente novoCliente = new Cliente(nome, idade, cpf, barbeiroFavorito);
            clientes.Add(novoCliente);
            Console.WriteLine("Cliente adicionado com sucesso!");
        }

        static void CriarBarbeiro()
        {
            Console.Write("Nome do Barbeiro: ");
            string nome = Console.ReadLine();
            Console.Write("Idade: ");
            int idade = Convert.ToInt32(Console.ReadLine());
            Console.Write("CPF: ");
            string cpf = Console.ReadLine();

            Barbeiro novoBarbeiro = new Barbeiro(nome, idade, cpf);
            barbeiros.Add(novoBarbeiro);
            AdicionarCortesAoBarbeiro(novoBarbeiro);
            Console.WriteLine("Barbeiro adicionado com sucesso!");
        }

        static void AdicionarCortesAoBarbeiro(Barbeiro barbeiro)
        {
            bool continuar = true;
            while (continuar)
            {
                Console.Write("Adicionar corte (Nome e preço): ");
                string entrada = Console.ReadLine();
                var partes = entrada.Split(',');

                if (partes.Length == 2)
                {
                    string nomeCorte = partes[0].Trim();
                    double precoCorte = Convert.ToDouble(partes[1].Trim());
                    barbeiro.AdicionarCorte(new Corte(nomeCorte, precoCorte));
                }

                Console.Write("Deseja adicionar mais cortes? (s/n): ");
                continuar = Console.ReadLine().ToLower() == "s";
            }
        }

        static void RegistrarCorte()
        {
            Console.WriteLine("Clientes:");
            for (int i = 0; i < clientes.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {clientes[i].Nome}");
            }

            Console.Write("Escolha um Cliente pelo número: ");
            int clienteIndex = Convert.ToInt32(Console.ReadLine()) - 1;

            Console.WriteLine("Barbeiros:");
            for (int i = 0; i < barbeiros.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {barbeiros[i].Nome}");
            }

            Console.Write("Escolha um Barbeiro pelo número: ");
            int barbeiroIndex = Convert.ToInt32(Console.ReadLine()) - 1;

            Console.Write("Nome do corte: ");
            string nomeCorte = Console.ReadLine();

            double precoCorte = barbeiros[barbeiroIndex].Cortes.Find(c => c.NomeCorte == nomeCorte)?.PrecoCorte ?? 0;

            if (precoCorte > 0)
            {
                lucroTotal += precoCorte;
                Console.WriteLine($"Corte registrado: {nomeCorte} por R$ {precoCorte}.");
            }
            else
            {
                Console.WriteLine("Corte não encontrado para o barbeiro selecionado.");
            }
        }
         static void MostrarRelatorio()
        {
            Console.WriteLine($"Total de clientes atendidos:");
            Console.WriteLine($"Total de clientes atendidos: {clientes.Count}");
            Console.WriteLine($"Lucro total do dia: R$ {lucroTotal:F2}");
        }

        static void CarregarDados()
        {
            if (File.Exists("dados.txt"))
            {
                var linhas = File.ReadAllLines("dados.txt");
                foreach (var linha in linhas)
                {
                    var partes = linha.Split(';');
                    if (partes.Length == 5 && partes[0] == "Cliente")
                    {
                        clientes.Add(new Cliente(partes[1], int.Parse(partes[2]), partes[3], partes[4]));
                    }
                    else if (partes.Length == 4 && partes[0] == "Barbeiro")
                    {
                        barbeiros.Add(new Barbeiro(partes[1], int.Parse(partes[2]), partes[3]));
                    }
                }
            }
            Console.WriteLine("Dados carregados com sucesso!");
        }

        static void SalvarDados()
        {
            using (StreamWriter writer = new StreamWriter("dados.txt"))
            {
                foreach (var cliente in clientes)
                {
                    writer.WriteLine($"Cliente;{cliente.Nome};{cliente.Idade};{cliente.Cpf};{cliente.BarbeiroFavorito}");
                }
                foreach (var barbeiro in barbeiros)
                {
                    writer.WriteLine($"Barbeiro;{barbeiro.Nome};{barbeiro.Idade};{barbeiro.Cpf}");
                }
            }
            Console.WriteLine("Dados salvos com sucesso!");
        }
    }