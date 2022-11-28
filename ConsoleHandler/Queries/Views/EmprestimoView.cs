using SistemaBiblioteca.Livro;

namespace SistemaBiblioteca.Usuario
{
    public class EmprestimoView
    {
        public int CodigoLivro { get; set; }
        public string? NomeLivro { get; set; }
        public int CodigoExemplar { get; set; }
        public int CodigoUsuario { get; set; }
        public DateTime SolicitacaoData { get; set; }
        public DateTime DevolucaoData { get; set; }
        public string NomeUsuario { get; set; }
        public EmprestimoStatus? Status { get; set; }
    }

}