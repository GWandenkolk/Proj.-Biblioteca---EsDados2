using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Biblioteca
{
    class Program
    {
        static Livros acervo = new Livros();

        static void Main(string[] args)
        {
            int opcao;
            do
            {
                Console.WriteLine("\n------ Menu ------");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar livro");
                Console.WriteLine("2. Pesquisar livro (sintético)");
                Console.WriteLine("3. Pesquisar livro (analítico)");
                Console.WriteLine("4. Adicionar exemplar");
                Console.WriteLine("5. Registrar empréstimo");
                Console.WriteLine("6. Registrar devolução");
                Console.WriteLine("-------------------");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarLivro();
                        break;
                    case 2:
                        PesquisarLivroSintetico();
                        break;
                    case 3:
                        PesquisarLivroAnalitico();
                        break;
                    case 4:
                        AdicionarExemplar();
                        break;
                    case 5:
                        RegistrarEmprestimo();
                        break;
                    case 6:
                        RegistrarDevolucao();
                        break;
                }
            } while (opcao != 0);
        }

        static void AdicionarLivro()
        {
            Console.Write("ISBN: ");
            int isbn = int.Parse(Console.ReadLine());
            Console.Write("Título: ");
            string titulo = Console.ReadLine();
            Console.Write("Autor: ");
            string autor = Console.ReadLine();
            Console.Write("Editora: ");
            string editora = Console.ReadLine();

            Livro livro = new Livro { Isbn = isbn, Titulo = titulo, Autor = autor, Editora = editora };
            acervo.Adicionar(livro);
            Console.WriteLine("Livro adicionado com sucesso.");
        }

        static void PesquisarLivroSintetico()
        {
            Console.Write("Informe o ISBN do livro: ");
            int isbn = int.Parse(Console.ReadLine());

            Livro livro = acervo.Pesquisar(isbn);
            if (livro != null)
            {
                Console.WriteLine($"Título: {livro.Titulo}");
                Console.WriteLine($"Autor: {livro.Autor}");
                Console.WriteLine($"Total de Exemplares: {livro.QtdeExemplares()}");
                Console.WriteLine($"Exemplares Disponíveis: {livro.QtdeDisponiveis()}");
                Console.WriteLine($"Total de Empréstimos: {livro.QtdeEmprestimos()}");
                Console.WriteLine($"Percentual de Disponibilidade: {livro.PercDisponibilidade():F2}%");
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        static void PesquisarLivroAnalitico()
        {
            Console.Write("Informe o ISBN do livro: ");
            int isbn = int.Parse(Console.ReadLine());

            Livro livro = acervo.Pesquisar(isbn);
            if (livro != null)
            {
                PesquisarLivroSintetico();
                foreach (var exemplar in livro.Exemplares)
                {
                    Console.WriteLine($"\nExemplar Tombo: {exemplar.Tombo}");
                    Console.WriteLine($"Quantidade de Empréstimos: {exemplar.QtdeEmprestimos()}");
                    foreach (var emprestimo in exemplar.Emprestimos)
                    {
                        Console.WriteLine($"Empréstimo em: {emprestimo.DtEmprestimo}");
                        if (emprestimo.DtDevolucao != default(DateTime))
                        {
                            Console.WriteLine($"Devolvido em: {emprestimo.DtDevolucao}");
                        }
                        else
                        {
                            Console.WriteLine("Ainda não devolvido.");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        static void AdicionarExemplar()
        {
            Console.Write("Informe o ISBN do livro: ");
            int isbn = int.Parse(Console.ReadLine());

            Livro livro = acervo.Pesquisar(isbn);
            if (livro != null)
            {
                Console.Write("Tombo do Exemplar: ");
                int tombo = int.Parse(Console.ReadLine());
                Exemplar exemplar = new Exemplar { Tombo = tombo };
                livro.AdicionarExemplar(exemplar);
                Console.WriteLine("Exemplar adicionado com sucesso.");
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        static void RegistrarEmprestimo()
        {
            Console.Write("Informe o ISBN do livro: ");
            int isbn = int.Parse(Console.ReadLine());

            Livro livro = acervo.Pesquisar(isbn);
            if (livro != null)
            {
                foreach (var exemplar in livro.Exemplares)
                {
                    if (exemplar.Disponivel())
                    {
                        exemplar.Emprestar();
                        Console.WriteLine("Empréstimo registrado com sucesso.");
                        return;
                    }
                }
                Console.WriteLine("Nenhum exemplar disponível.");
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        static void RegistrarDevolucao()
        {
            Console.Write("Informe o ISBN do livro: ");
            int isbn = int.Parse(Console.ReadLine());

            Livro livro = acervo.Pesquisar(isbn);
            if (livro != null)
            {
                foreach (var exemplar in livro.Exemplares)
                {
                    if (!exemplar.Disponivel())
                    {
                        exemplar.Devolver();
                        Console.WriteLine("Devolução registrada com sucesso.");
                        return;
                    }
                }
                Console.WriteLine("Nenhum exemplar para devolver.");
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }
    }
}



