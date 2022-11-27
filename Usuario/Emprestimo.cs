namespace SistemaBiblioteca.Usuario
{
    public class Emprestimo
    {
        public int CodigoLivro { get; set; }
        public int CodigoExemplar { get; set; }
        public int CodigoUsuario { get; set; }
        public string Status { get; set; }
        public DateTime SolicitacaoData { get; set; }
        public DateTime DevolucaoData { get; set; }

         public Emprestimo (int codigoLivro, int codigoExemplar, int codigoUsuario, DateTime devolucaoData)
        {
            CodigoLivro = codigoLivro;
            CodigoUsuario = codigoUsuario;
            Status = "ativo";
            SolicitacaoData = DateTime.now;
            DevolucaoData = devolucaoData;
        }
    }

}