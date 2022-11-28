namespace SistemaBiblioteca.Usuario
{
    public class ReservaView : Reserva
    {
        public string NomeUsuario { get; set; }

        public ReservaView(int codigoLivro, int codigoUsuario, string nomeUsuario)
            : base(codigoLivro, codigoUsuario)
        {
            NomeUsuario = nomeUsuario;
        }

    }

}