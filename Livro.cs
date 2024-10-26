using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Biblioteca
{

    public class Livro
    {
        public int Isbn { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public List<Exemplar> Exemplares { get; set; } = new List<Exemplar>();

        public void AdicionarExemplar(Exemplar exemplar)
        {
            Exemplares.Add(exemplar);
        }

        public int QtdeExemplares()
        {
            return Exemplares.Count;
        }

        public int QtdeDisponiveis()
        {
            int disponiveis = 0;
            foreach (var exemplar in Exemplares)
            {
                if (exemplar.Disponivel())
                    disponiveis++;
            }
            return disponiveis;
        }

        public int QtdeEmprestimos()
        {
            int totalEmprestimos = 0;
            foreach (var exemplar in Exemplares)
            {
                totalEmprestimos += exemplar.QtdeEmprestimos();
            }
            return totalEmprestimos;
        }

        public double PercDisponibilidade()
        {
            if (Exemplares.Count == 0) return 0;
            return (double)QtdeDisponiveis() / QtdeExemplares() * 100;
        }
    }
}
