using Proj.Biblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Biblioteca
{
    public class Livros
    {
        public List<Livro> Acervo { get; set; } = new List<Livro>();

        public void Adicionar(Livro livro)
        {
            Acervo.Add(livro);
        }

        public Livro Pesquisar(int isbn)
        {
            return Acervo.Find(livro => livro.Isbn == isbn);
        }
    }
}
