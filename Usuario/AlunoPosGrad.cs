namespace SistemaBiblioteca.Usuario
{
    public class AlunoPosGrad : Usuario
    {
        public AlunoPosGrad(int codigo, string nome) : base(codigo, nome) { }

        public override string Devolver()
        {
            throw new NotImplementedException();
        }

        public override string Emprestar()
        {
            return "Livro Emprestado por 4 dias";
        }

        public override string Reservar()
        {
            throw new NotImplementedException();
        }
    }
}
