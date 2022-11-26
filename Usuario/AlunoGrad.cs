namespace SistemaBiblioteca.Usuario
{
    public class AlunoGrad : Usuario
    {
        public AlunoGrad(int codigo, string nome) : base(codigo, nome) { }

        public override string Devolver()
        {
            throw new NotImplementedException();
        }

        public override string Reservar()
        {
            throw new NotImplementedException();
        }

        private override DateTime CalcularDataDevolucao()
        {
            DateTime now = DateTime.now;
            return now.AddDays(3);
        }

        private override Tuple<bool, string> PodePegarEmprestimo(Livro livro, Exemplar exemplares)
        {
            if(Reservas.Length >= 3)
            {
                return (false, 'Emprestimo negado! Já existem muitos emprestimos ativos.');
            }

            var reservasDoUsuario = livro.Reservas.FindAll(reserva => reserva.codigoUsuario == codigoUsuario);
            
            if(!reservasDoUsuario && exemplares.Length <= livro.Reservas.Length)
            {
                return (false, 'Emprestimo negado! Todos os Exemplares já estão reservados!');
            }          

            return (true, 'Tudo OK!');
        }
    }
}
