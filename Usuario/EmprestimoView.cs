namespace SistemaBiblioteca.Usuario
{
    public class EmprestimoView: Emprestimo
    {
        public string NomeUsuario

         public EmprestimoView (int codigoLivro, int codigoExemplar, int codigoUsuario, DateTime devolucaoData, string nomeUsuario) :base(codigoLivro, codigoExemplar, codigoUsuario, devolucaoData)
        {
           NomeUsuario = nomeUsuario;
        }
    }

}