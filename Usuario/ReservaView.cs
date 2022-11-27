namespace SistemaBiblioteca.Usuario
{
    public class ReservaView: reserva
    {
        public string NomeUsuario { get; set; }

        public ReservaView(int codigoLivro, int codigoUsuario, DateTime solicitacaoData, string nomeUsuario) :base(codigoLivro, codigoUsuario, solicitacaoData)
        {
            NomeUsuario = nomeUsuario;
        }

    }

}