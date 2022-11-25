using System.Linq;
namespace SistemaBiblioteca.Usuario

{
    public class Biblioteca
    {
        public List<Livro> Livros { get; set; }
        public List<Usuario> Usuarios { get; set; }
        public Exemplar Exemplares { get; set; }

        public Biblioteca()
        {
            InicializaLivros();
            InicializaUsuarios();
            InicializaEmprestimos();
        }


        public string Emprestar(int codigoUsuario, int codigoLivro)
        {
            var usuarioAtual = this.Usuarios.FindAll(usuario => usuario.codigo == codigoUsuario);

            var usuarioAtualizado = usuarioAtual.Emprestar(codigoLivro);
            this.Usuarios.Remove(usuarioAtual);
            this.Usuarios.Add(usuarioAtualizado);
        }


        public string Reservar(int codigoUsuario, int codigoLivro)
        {
            var usuarioAtual = this.Usuarios.FindAll(usuario => usuario.codigo == codigoUsuario);

            var usuarioAtualizado = usuarioAtual.Reservar(codigoLivro);
            this.Usuarios.Remove(usuarioAtual);
            this.Usuarios.Add(usuarioAtualizado);
        }


        public string Devolver(int codigoUsuario, int codigoLivro)
        {
            var usuarioAtual = this.Usuarios.FindAll(usuario => usuario.codigo == codigoUsuario);

            var usuarioAtualizado = usuarioAtual.Devolver(codigoLivro);
            this.Usuarios.Remove(usuarioAtual);
            this.Usuarios.Add(usuarioAtualizado);
        }

        public string getLivros() { return "livros"; }
        public list<Emprestimo> getEmprestimos() { }
        public Usuario getUsuario(int codigoUsuario) { }
        public int getNotificacoes(int codigoProfessor) { }

        public void adicionarObservavel(int codigoUsuario, int codigoLivro)
        {
            var usuarioAtual = this.Usuarios.FindAll(usuario => usuario.codigo == codigoUsuario);
            var livroAtual = this.Usuarios.FindAll(livro => livro.codigo == codigoLivro);
            
            this.Usuarios.Remove(usuarioAtual);

            usuarioAtual.AddObservable(codigoLivro);
            
            this.Usuarios.Add(usuarioAtual);
        }


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
