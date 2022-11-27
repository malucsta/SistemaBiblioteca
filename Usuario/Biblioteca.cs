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
            
            var (livroAtual) = Livros.FindAll(livro => livro.Codigo == codigoLivro);
            var exemplarAtual = Exemplares.FindAll(exemplar => exemplar.CodigoLivro == codigoLivro && exemplar.Status == 'Disponivel'); 
            
            if (exemplarAtual.Length < 1)
            {
                return 'Nenhum Exemplar disponível!';
            }
            
            var usuarioAtual = Usuarios.FindAll(usuario => usuario.Codigo == codigoUsuario);
            
            Usuarios.Remove(usuarioAtual);
            usuarioAtual.Emprestar(livroAtual, exemplarAtual);
            Usuarios.Add(usuarioAtual);


            Exemplares.Remove(exemplarAtual[0]);
            exemplarAtual[0].Emprestar();
            Exemplares.Add(exemplarAtual[0]);
        }


        public string Reservar(int codigoUsuario, int codigoLivro)
        {
            var (usuarioAtual) = Usuarios.FindAll(usuario => usuario.Codigo == codigoUsuario);
            var (livroAtual) = Livros.FindAll(livro => livroCodigo == codigoLivro);
            Reserva reserva = new Reserva(codigoLivro, codigoUsuario, DateTime.now);

            var usuarioAtualizado = usuarioAtual.Reservar(reserva);
            Usuarios.Remove(usuarioAtual);
            Usuarios.Add(usuarioAtualizado);

            Livros.Remove(livroAtual);
            
            (string mensagem, List<Usuario> usuariosModificados) = livroAtual.AddReserva(reserva, Usuarios);
            
            Livros.Add(livroAtualizado);

            Usuarios = usuariosModificados;

            return mensagem;

            
        }


        public string Devolver(int codigoUsuario, int codigoLivro)
        {
            var usuarioAtual = Usuarios.FindAll(usuario => usuario.Codigo == codigoUsuario);

            var usuarioAtualizado = usuarioAtual.Devolver(codigoLivro);
            Usuarios.Remove(usuarioAtual);
            Usuarios.Add(usuarioAtualizado);
        }

        public string getLivros() { return "livros"; }
        public list<Emprestimo> getEmprestimos() { }
        public Usuario getUsuario(int codigoUsuario) { }
        public int getNotificacoes(int codigoProfessor) { }

        public void adicionarObservavel(int codigoUsuario, int codigoLivro)
        {
            var (usuarioAtual) = Usuarios.FindAll(usuario => usuario.Codigo == codigoUsuario);
            var (livroAtual) = Livros.FindAll(livro => livro.Codigo == codigoLivro);
            
            Usuarios.Remove(usuarioAtual);
            usuarioAtual.AddObservable(codigoLivro);
            Usuarios.Add(usuarioAtual);

            Livros.Remove(livroAtual);
            livroAtual.AddObserver(usuarioAtual);
            Livros.Add(livroAtual);
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
