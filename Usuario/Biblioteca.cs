using System.Linq;
namespace SistemaBiblioteca.Usuario

{
    public class Biblioteca
    {
        public Livro Livros { get; set; }
        public List<Usuario> Usuarios { get; set; }
        public Exemplar Exemplares { get; set; }

        public Biblioteca()
        {
            InicializaLivros();
            InicializaUsuarios();
            InicializaEmprestimos();
        }


        public string Emprestar(int codUsuario, int codigoLivro)
        {
            var usuarioAtual = this.Usuarios.FindAll(usuario => usuario.codigo == codUsuario);

            var usuarioAtualizado = usuarioAtual.Emprestar(codigoLivro);
            this.Usuarios.Remove(usuarioAtual);
            this.Usuarios.Add(usuarioAtualizado);
        }


        public string Reservar(int codUsuario, int codigoLivro)
        {
            var usuarioAtual = this.Usuarios.FindAll(usuario => usuario.codigo == codUsuario);

            var usuarioAtualizado = usuarioAtual.Reservar(codigoLivro);
            this.Usuarios.Remove(usuarioAtual);
            this.Usuarios.Add(usuarioAtualizado);
        }


        public string Devolver(int codUsuario, int codigoLivro)
        {
            var usuarioAtual = this.Usuarios.FindAll(usuario => usuario.codigo == codUsuario);

            var usuarioAtualizado = usuarioAtual.Devolver(codigoLivro);
            this.Usuarios.Remove(usuarioAtual);
            this.Usuarios.Add(usuarioAtualizado);
        }

        public string getLivros() { return "livros"; }
        public list<Emprestimo> getEmprestimos() { }
        public Usuario getUsuario(int codigoUsuario) { }
        public int getNotificacoes(int codigoProfessor) { }


        public void InicializaUsuarios()
        {
            List<Usuario> usuariosBiblioteca = new List<Usuario>();
            usuariosBiblioteca.Add(new AlunoGrad(123, "João da Silva"));
            usuariosBiblioteca.Add(new AlunoPosGrad(456, "Luiz Fernando Rodrigues"));
            usuariosBiblioteca.Add(new AlunoGrad(789, "Pedro Paulo"));
            usuariosBiblioteca.Add(new Professor(100, "Carlos Lucena"));

            Usuarios = usuariosBiblioteca;
        }

        public void InicializaLivros()
        {
            //todo: implementar a inicialização dos livros
        }

        public void InicializaEmprestimos()
        {
            //todo: implementar a inicialização dos emprestimos
        }
    }
}
