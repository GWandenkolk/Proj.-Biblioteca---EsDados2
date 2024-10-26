using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Biblioteca
{
    public class Exemplar
    {
        public int Tombo { get; set; }
        public List<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();

        public bool Disponivel()
        {
            if (Emprestimos.Count == 0) return true;
            return Emprestimos[Emprestimos.Count - 1].DtDevolucao != default(DateTime);
        }

        public bool Emprestar()
        {
            if (Disponivel())
            {
                Emprestimos.Add(new Emprestimo { DtEmprestimo = DateTime.Now });
                return true;
            }
            return false;
        }

        public bool Devolver()
        {
            if (!Disponivel())
            {
                Emprestimos[Emprestimos.Count - 1].DtDevolucao = DateTime.Now;
                return true;
            }
            return false;
        }

        public int QtdeEmprestimos()
        {
            return Emprestimos.Count;
        }
    }
}
