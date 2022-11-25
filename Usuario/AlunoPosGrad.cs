namespace SistemaBiblioteca.Usuario
{
    public abstract class AlunoPosGrad : Usuario
    {
         public override string Emprestar()
        {
            return "Livro Emprestado por 4 dias";
        }
    }
}
