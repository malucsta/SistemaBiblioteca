using System.Linq;
using SistemaBiblioteca.Livro;

namespace SistemaBiblioteca.Usuario

{
    public sealed class Biblioteca
    {
        public List<Livro> Livros { get; set; } = new List<Livro>();
        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
        public List<Exemplar> Exemplares { get; set; } = new List<Exemplar>();
        private static Biblioteca _instancia;

        private Biblioteca()
        {
            InicializaLivros();
            InicializaUsuarios();
            InicializaExemplares();
        }

        public static Biblioteca GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new Biblioteca();
            }
            return _instancia;
        }

        public Usuario? GetUsuario(int codigoUsuario)
        {
            return Usuarios.Find(usuario => usuario.Codigo == codigoUsuario);
        }

        public Livro? GetLivro(int codigoLivro)
        {
            return Livros.Find(livro => livro.Codigo == codigoLivro);
        }


        public string Emprestar(int codigoUsuario, int codigoLivro)
        {
            var usuario = GetUsuario(codigoUsuario);
            var livro = GetLivro(codigoLivro);

            if (usuario is null) return "Usuário não existe";
            if (livro is null) return "Livro não existe";

            return usuario.Emprestar(livro);
        }


        public string Reservar(int codigoUsuario, int codigoLivro)
        {
            var usuario = GetUsuario(codigoUsuario);
            var livro = GetLivro(codigoLivro);

            if (usuario is null) return "Usuário não existe";
            if (livro is null) return "Livro não existe";

            return usuario.Reservar(livro);
        }


        public string Devolver(int codigoUsuario, int codigoLivro)
        {
            var usuario = GetUsuario(codigoUsuario);
            var livro = GetLivro(codigoLivro);

            if (usuario is null) return "Usuário não existe";
            if (livro is null) return "Livro não existe";

            var emprestimo = usuario.Emprestimos.Find(emprestimo => emprestimo.CodigoLivro == codigoLivro);
            if (emprestimo is null) return $"Emprestimo do livro em questão não existe para o usuário {usuario.Codigo}";

            var exemplar = livro.Exemplares.Find(exemplar => exemplar.CodigoExemplar == emprestimo.CodigoExemplar);
            if (exemplar is null) return $"Exemplar do livro em questão não existe para o usuário {usuario.Codigo}";

            return usuario.Devolver(ref exemplar);
        }

        // public string GetLivros(int codigoLivro)
        // {
        //     var livro = GetLivro(codigoLivro);
        //     var exemplares = Exemplares.FindAll(exemplar => exemplar.CodigoLivro == codigoLivro);

        //     List<ReservaView> nomeUsuariosReservas;
        //     foreach (var reserva in livro.Reserva)
        //     {
        //         (Usuario usuarioReserva) = Usuarios.FindAll(usuario => usuario.Codigo == reserva.CodigoUsuario);
        //         nomeUsuariosReservas.Add(new ReservaView(codigoLivro, reserva.CodigoUsuario, reserva.SolicitacaoData, usuarioReserva.Nome));
        //     }

        //     List<EmprestimoView> nomeUsuariosEmprestimos;
        //     foreach (var exemplar in exemplares)
        //     {
        //         foreach (var emprestimo in exemplar.Emprestimos)
        //         {
        //             (Usuario usuarioEmprestimo) = Usuarios.FindAll(usuario => usuario.Codigo == emprestimo.CodigoUsuario);
        //             nomeUsuariosEmprestimos.Add(new EmprestimoView(codigoLivro, exemplar.CodigoExemplar, emprestimo.CodigoUsuario, emprestimo.DevolucaoData, usuarioEmprestimo.Nome));

        //         }
        //     }
        // }

        public string? AcompanharLivro(int codigoUsuario, int codigoLivro)
        {
            var usuario = GetUsuario(codigoUsuario);
            var livro = GetLivro(codigoLivro);

            if (livro is null) return "Livro não encontrado";

            if (usuario is UsuarioObservador) livro.AddObserver((UsuarioObservador)usuario);
            return null;
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
            List<Livro> livrosBiblioteca = new List<Livro>();
            livrosBiblioteca.Add(new Livro(100, "Eng de Software", "Addison", "Ian Sommervile", "6", "2000"));
            livrosBiblioteca.Add(new Livro(101, "UML - Guia do Usuario", "Addison", "Ian Sommervile", "6", "2000"));
            livrosBiblioteca.Add(new Livro(200, "Code Complete", "Addison", "Ian Sommervile", "6", "2000"));
            livrosBiblioteca.Add(new Livro(201, "Agile Software", "Addison", "Ian Sommervile", "6", "2000"));
            livrosBiblioteca.Add(new Livro(300, "Refactoring: imroving the Design of Existing Code", "Addison", "Ian Sommervile", "6", "2000"));
            livrosBiblioteca.Add(new Livro(301, "Software Metrics: ARigorous and Practical Approach", "Addison", "Ian Sommervile", "6", "2000"));
            livrosBiblioteca.Add(new Livro(400, "Design Patterns", "Addison", "Ian Sommervile", "6", "2000"));
            livrosBiblioteca.Add(new Livro(401, "UML Distilled", "Addison", "Ian Sommervile", "6", "2000"));
        }

        public void InicializaExemplares()
        {
            List<Exemplar> exemplaresBiblioteca = new List<Exemplar>();
            exemplaresBiblioteca.Add(new Exemplar(100, 01, EmprestimoStatus.Disponivel));
            exemplaresBiblioteca.Add(new Exemplar(100, 02, EmprestimoStatus.Disponivel));
            exemplaresBiblioteca.Add(new Exemplar(101, 03, EmprestimoStatus.Disponivel));
            exemplaresBiblioteca.Add(new Exemplar(200, 04, EmprestimoStatus.Disponivel));
            exemplaresBiblioteca.Add(new Exemplar(201, 05, EmprestimoStatus.Disponivel));
            exemplaresBiblioteca.Add(new Exemplar(300, 06, EmprestimoStatus.Disponivel));
            exemplaresBiblioteca.Add(new Exemplar(300, 07, EmprestimoStatus.Disponivel));
            exemplaresBiblioteca.Add(new Exemplar(400, 08, EmprestimoStatus.Disponivel));
            exemplaresBiblioteca.Add(new Exemplar(400, 09, EmprestimoStatus.Disponivel));
        }
    }
}
