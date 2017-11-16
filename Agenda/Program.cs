using Agenda.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agenda
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputKey = string.Empty;

            List<PhonebookEntry> listaTelefonica = new List<PhonebookEntry>();

            while (inputKey.ToUpper() != "S")
            {
                
                Console.WriteLine("Bem Vindo a Sua Agenda");
                Console.WriteLine("Escolha a Opção Desejada!");
                Console.WriteLine("1- Cadastrar");
                Console.WriteLine("2- Lista de Cadastrados");
                Console.WriteLine("3- Pesquisar");
                Console.WriteLine("4- Remover");
                Console.WriteLine("S- Sair");
                Console.WriteLine();

                inputKey = Console.ReadLine();
                Console.WriteLine();

                if (inputKey == "1")
                {
                    PhonebookEntry entrada = new PhonebookEntry();
                    Console.WriteLine("Digite o nome");
                    entrada.Nome = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Digite o telefone");
                    entrada.Telefone = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Digite o endereço");
                    entrada.Endereço = Console.ReadLine();
                    Console.WriteLine();

                    listaTelefonica.Add(entrada);
                }
                else if (inputKey == "2")
                {
                    int posicao = 0;

                    foreach (PhonebookEntry item in listaTelefonica.OrderBy(x => x.Nome))
                    {
                        Console.WriteLine();
                        Console.WriteLine($"{posicao}. {item.Nome}");
                        posicao++;
                    }
                }
                else if (inputKey == "3")
                {

                    Console.WriteLine("Digite o Nome da Pessoa que Deseja Pesquisar");

                    string nomePesquisado = Console.ReadLine();
                    List<PhonebookEntry> listaDePesquisados = new List<PhonebookEntry>();

                    foreach (PhonebookEntry item in listaTelefonica.Where(x => x.Nome.ToUpper().Contains(nomePesquisado.Trim().ToUpper())))
                    {

                        listaDePesquisados.Add(item);

                    }

                    //listaTelefonica.FirstOrDefault(x => x.Nome.ToUpper().Contains(nomePesquisado.ToUpper()));

                    if (listaDePesquisados.Count > 0)
                    {
                        foreach (PhonebookEntry item in listaDePesquisados)
                        {

                            Console.WriteLine(item.Nome);
                            Console.WriteLine(item.Telefone);
                            Console.WriteLine(item.Endereço);
                            Console.WriteLine();

                        }
                    }

                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Nenhuma Correspondência Encontrada");
                        Console.WriteLine();
                    }

                    /*List<string> listaDeString = new List<string>();
                    foreach (string itemDaVez in listaDeString)
                    {
                        Console.WriteLine(itemDaVez); 
                    } */
                }
                else if (inputKey == "4")
                {

                    Console.WriteLine("Digite o Nome da Pessoa que Deseja Excluir");

                    string nomeAExcluir = Console.ReadLine();

                    PhonebookEntry phonebookEntry = listaTelefonica.FirstOrDefault(x => x.Nome.ToUpper().Equals(nomeAExcluir.ToUpper()));

                    if (phonebookEntry == null)
                    {
                        Console.WriteLine("Nome não encontrado");
                    }

                    else
                    {
                        listaTelefonica.Remove(phonebookEntry);

                        Console.WriteLine("Exclusão feita com sucesso");
                    }
                }
            }
        }
    }
}
