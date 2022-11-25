namespace SistemaBiblioteca.Usuario
{
    public abstract class AlunoGrad : Usuario
    {
        public override string Emprestar()
        {
            return "Livro Emprestado por 3 dias";
        }
    }
}
