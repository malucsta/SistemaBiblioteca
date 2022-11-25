namespace SistemaBiblioteca.Usuario
{
    public class Emprestimo
    {
        public string codigoLivro { get; set; }
        public string codigoUsuario { get; set; }
        public string status { get; set; }
        public DateTime solicitacaoData { get; set; }
        public DateTime devolucaoData { get; set; }
    }

}