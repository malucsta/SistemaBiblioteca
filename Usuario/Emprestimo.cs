namespace SistemaBiblioteca.Usuario
{
    public class Emprestimo
    {
        public string CodigoLivro { get; set; }
        public string CodigoUsuario { get; set; }
        public string Status { get; set; }
        public DateTime SolicitacaoData { get; set; }
        public DateTime DevolucaoData { get; set; }

         public Emprestimo (string codigoLivro, string codigoUsuario, DateTime devolucaoData)
        {
            CodigoLivro = codigoLivro;
            CodigoUsuario = codigoUsuario;
            Status = 'ativo';
            SolicitacaoData = DateTime.now;
            DevolucaoData = devolucaoData;
        }
    }

}