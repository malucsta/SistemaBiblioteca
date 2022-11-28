namespace SistemaBiblioteca.Usuario
{
    public class EmprestimoView : Emprestimo
    {
        public string NomeUsuario { get; set; }

        public EmprestimoView(int codigoLivro, int codigoExemplar, int codigoUsuario, string nomeUsuario)
            : base(codigoLivro, codigoExemplar, codigoUsuario)
        {
            NomeUsuario = nomeUsuario;
        }
    }

}