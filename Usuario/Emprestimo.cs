namespace SistemaBiblioteca.Usuario
{
    public class Emprestimo 
    {
        public string codigoLivro { get; set; }
        public string codigoUsuario { get; set; }
        public string status { get; set; }
        public Date solicitacaoData { get; set; }
        public Date devolucaoData { get; set; }
    }

}