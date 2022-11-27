namespace SistemaBiblioteca.Usuario
{
    public class Reserva
    {
        public int CodigoLivro { get; set; }
        public int CodigoUsuario { get; set; }
        public DateTime SolicitacaoData { get; set; }

        public Reserva(int codigoLivro, int codigoUsuario, DateTime solicitacaoData)
        {
            CodigoLivro = codigoLivro;
            CodigoUsuario = codigoUsuario;
            SolicitacaoData = solicitacaoData;
        }

    }

}