namespace SistemaBiblioteca.Usuario
{
    public class AlunoGrad : Usuario
    {
        public AlunoGrad(int codigo, string nome) : base(codigo, nome) { }

        public override string Devolver()
        {
            throw new NotImplementedException();
        }

        public override string Emprestar()
        {
            return "Livro Emprestado por 3 dias";
        }

        public override string Reservar()
        {
            throw new NotImplementedException();
        }
    }
}
