using System.Linq;
using SistemaBiblioteca.Livro;

namespace SistemaBiblioteca.Usuario

{
    public sealed class Biblioteca
    {
        public List<Livro> Livros { get; set; } = new List<Livro>();
        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
        public List<Exemplar> Exemplares { get; set; } = new List<Exemplar>();
        private static Biblioteca _instancia = new Biblioteca();

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

            return usuario.Emprestar(ref livro, Exemplares);
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


        private void InicializaUsuarios()
        {
            List<Usuario> usuariosBiblioteca = new List<Usuario>();
            usuariosBiblioteca.Add(new AlunoGrad(123, "João da Silva"));
            usuariosBiblioteca.Add(new AlunoPosGrad(456, "Luiz Fernando Rodrigues"));
            usuariosBiblioteca.Add(new AlunoGrad(789, "Pedro Paulo"));
            usuariosBiblioteca.Add(new Professor(100, "Carlos Lucena"));

            Usuarios = usuariosBiblioteca;
        }

        private void InicializaLivros()
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

            Livros = livrosBiblioteca;
        }

        private void InicializaExemplares()
        {
            List<Exemplar> exemplaresBiblioteca = new List<Exemplar>();

            var livro100 = GetLivro(100);
            var exemplar1001 = new Exemplar(100, 01, EmprestimoStatus.Disponivel);
            var exemplar1002 = new Exemplar(100, 02, EmprestimoStatus.Disponivel);
            livro100.AdicionarExemplares(ref exemplar1001);
            livro100.AdicionarExemplares(ref exemplar1002);
            exemplaresBiblioteca.Add(exemplar1001);
            exemplaresBiblioteca.Add(exemplar1002);

            var livro101 = GetLivro(101);
            var exemplar10103 = new Exemplar(101, 03, EmprestimoStatus.Disponivel);
            livro101.AdicionarExemplares(ref exemplar10103);
            exemplaresBiblioteca.Add(exemplar10103);

            var livro200 = GetLivro(200);
            var exemplar20004 = new Exemplar(200, 04, EmprestimoStatus.Disponivel);
            livro200.AdicionarExemplares(ref exemplar20004);
            exemplaresBiblioteca.Add(exemplar20004);

            var livro201 = GetLivro(201);
            var exemplar20105 = new Exemplar(201, 05, EmprestimoStatus.Disponivel);
            livro200.AdicionarExemplares(ref exemplar20105);
            exemplaresBiblioteca.Add(exemplar20105);

            var livro300 = GetLivro(300);
            var exemplar30006 = new Exemplar(300, 06, EmprestimoStatus.Disponivel);
            var exemplar30007 = new Exemplar(300, 07, EmprestimoStatus.Disponivel);
            livro300.AdicionarExemplares(ref exemplar30006);
            livro300.AdicionarExemplares(ref exemplar30007);
            exemplaresBiblioteca.Add(exemplar30006);
            exemplaresBiblioteca.Add(exemplar30007);

            var livro400 = GetLivro(400);
            var exemplar40008 = new Exemplar(400, 08, EmprestimoStatus.Disponivel);
            var exemplar40009 = new Exemplar(400, 09, EmprestimoStatus.Disponivel);
            livro400.AdicionarExemplares(ref exemplar30006);
            livro400.AdicionarExemplares(ref exemplar30007);
            exemplaresBiblioteca.Add(exemplar40008);
            exemplaresBiblioteca.Add(exemplar40009);

            Exemplares = exemplaresBiblioteca;
        }
    }
}
