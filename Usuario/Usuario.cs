using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBiblioteca.Usuario
{
    public abstract class Usuario
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }

        public Usuario(int codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;
        }

        public abstract string Emprestar();
        public abstract string Reservar();
        public abstract string Devolver();
    }
}
