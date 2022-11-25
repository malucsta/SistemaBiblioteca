using System.Linq;
namespace SistemaBiblioteca.Usuario

{
    public class Biblioteca
    {
        public Livro Livros { get; set; };
        public Usuario Usuarios { get; set; };
        public Exemplar Exemplares { get; set; };

        public Biblioteca(list<Livro> livros, list<Usuario> usuarios, list<Exemplar> exemplares) {
            Livros = livros;
            Usuarios = this.FormatarUsuarios(usuarios);
            Exemplares = exemplares;
        };


        public string Emprestar(int codUsuario, int codigoLivro) 
        {
            var usuarioAtual = this.Usuarios.FindAll(usuario => usuario.codigo == codUsuario);

            var usuarioAtualizado = usuarioAtual.Emprestar(codigoLivro);
            this.Usuarios.Remove(usuarioAtual);
            this.Usuarios.Add(usuarioAtualizado);
        };


        public string Reservar(int codUsuario, int codigoLivro)
        {
            var usuarioAtual = this.Usuarios.FindAll(usuario => usuario.codigo == codUsuario);
            
            var usuarioAtualizado = usuarioAtual.Reservar(codigoLivro);
            this.Usuarios.Remove(usuarioAtual);
            this.Usuarios.Add(usuarioAtualizado);
        };


        public string Devolver(int codUsuario, int codigoLivro)
        {
            var usuarioAtual = this.Usuarios.FindAll(usuario => usuario.codigo == codUsuario);
            
            var usuarioAtualizado = usuarioAtual.Devolver(codigoLivro);
            this.Usuarios.Remove(usuarioAtual);
            this.Usuarios.Add(usuarioAtualizado);
        };
        public string getLivros();
        public list<Emprestimo> getEmprestimos();
        public Usuario getUsuario(int codigoUsuario);
        public int getNotificacoes(int codigoProfessor);


        public list<Usuario> FormatarUsuarios(list<Usuario> usuarios)
        {
            return usuarios.Select(usuario => {
            if (usuario.tipo == 'Aluno de Graduação') {
                usuario = new AlunoGrad(codUsuario, usuario.nome);
            }
            if (usuario.tipo == 'Aluno de Pós-graduação') {
                usuario = new AlunoPosGrad(codUsuario, usuario.nome);
            }
            if (usuario.tipo == 'Professor') {
                usuario = new Professor(codUsuario, usuario.nome);
            }
            }).ToArray();

        };
    }
}
