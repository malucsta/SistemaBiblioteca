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
            var exemplarAtual = Exemplares.FindAll(exemplar => exemplar.CodigoLivro == codigoLivro && exemplar.Status == "Disponivel"); 
            
            if (exemplarAtual.Length < 1)
            {
                return "Nenhum Exemplar disponível!";
            }
            
            var usuarioAtual = Usuarios.FindAll(usuario => usuario.Codigo == codigoUsuario);
            
            Usuarios.Remove(usuarioAtual);
            (bool emprestadoComSucesso, string mensagem, Emprestimo emprestimo) = usuarioAtual.Emprestar(livroAtual, exemplarAtual);
            Usuarios.Add(usuarioAtual);

            if(emprestadoComSucesso)
            {
                Exemplares.Remove(exemplarAtual[0]);
                exemplarAtual[0].Emprestar(emprestimo);
                Exemplares.Add(exemplarAtual[0]);

                var reservas = livroAtual.Reservas.FindAll(reserva => reserva.CodigoUsuario == codigoUsuario);
                if(reservas.Length > 0)
                {
                    Livros.Remove(livroAtual);
                    livroAtual.Reservas.Remove(reservas[0]);
                    Livros.Add(livroAtual);
                }

                return mensagem;
            }            

            return mensagem;
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
            var (usuarioAtual) = Usuarios.FindAll(usuario => usuario.Codigo == codigoUsuario);
            var (exemplarAtual) = Exemplares.FindAll(exemplar => exemplar.CodigoExemplar == codigoExemplar);
            var (livroAtual) = Livros.FindAll(livro => livro.Codigo == exemplarAtual.CodigoLivro);
            
            Usuarios.Remove(usuarioAtual);
            (bool devolvidoComSucesso, string mensagem, Emprestimo emprestimo) = usuarioAtual.Devolver(exemplarAtual, livroAtual.Nome);
            if(devolvidoComSucesso)
            {   
                Exemplares.Remove(exemplarAtual);
                exemplarAtual.Devolver(emprestimo);
                Exemplares.Add(exemplarAtual);

                Usuarios.Add(usuarioAtualizado);
                return mensagem;
            }

            Usuarios.Add(usuarioAtualizado);

            return mensagem;
        }

        public string getLivros(int codigoLivro)
        {
            (Livro livro) = Livros.FindAll(livro => livro.Codigo == codigoLivro);
            var exemplares = Exemplares.FindAll(exemplar => exemplar.CodigoLivro == codigoLivro);

            List<ReservaView> nomeUsuariosReservas;
            foreach (var reserva in livro.Reserva)
            {
                (Usuario usuarioReserva) = Usuarios.FindAll(usuario => usuario.Codigo == reserva.CodigoUsuario);
                nomeUsuariosReservas.Add(new ReservaView(codigoLivro, reserva.CodigoUsuario, reserva.SolicitacaoData, usuarioReserva.Nome));
            }

            List<EmprestimoView> nomeUsuariosEmprestimos;
            foreach (var exemplar in exemplares)
            {
                foreach (var emprestimo in exemplar.Emprestimos)
                {
                    (Usuario usuarioEmprestimo) = Usuarios.FindAll(usuario => usuario.Codigo == emprestimo.CodigoUsuario);
                    nomeUsuariosEmprestimos.Add(new EmprestimoView(codigoLivro, exemplar.CodigoExemplar, emprestimo.CodigoUsuario, emprestimo.DevolucaoData, usuarioEmprestimo.Nome));

                }
            }
            // Ai vc olha como fica o melhor retorno pra vc, pensei em criar uma classe pra esse retorno, mas acho que da pra retornar uma tupla com tudo junto tbm
        }
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
