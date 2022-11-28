namespace SistemaBiblioteca.Usuario
{
    public class Reserva
    {
        public int CodigoLivro { get; set; }
        public int CodigoUsuario { get; set; }

        public Reserva(int codigoLivro, int codigoUsuario)
        {
            CodigoLivro = codigoLivro;
            CodigoUsuario = codigoUsuario;
        }

    }
}