namespace SistemaBiblioteca.Usuario
{
    public class Reserva
    {
        public int CodigoLivro { get; set; }
        public int CodigoUsuario { get; set; }
        public DateTime DataSolicitacao { get; set; }

        public Reserva(int codigoLivro, int codigoUsuario)
        {
            CodigoLivro = codigoLivro;
            CodigoUsuario = codigoUsuario;
            DataSolicitacao = DateTime.Now;
        }

        public override string ToString()
        {
            return $"==> Reserva do livro {CodigoLivro} para o usuário {CodigoUsuario}";
        }

    }
}