namespace SistemaBiblioteca.Usuario
{
    public class AlunoPosGrad : Usuario
    {
        public AlunoPosGrad(int codigo, string nome) : base(codigo, nome) { }

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
            return now.AddDays(4);
        }

        private override Tuple<bool, string> PodePegarEmprestimo()
        {
             if(Reservas.Length >= 4)
            {
                return (false, "Emprestimo negado! Já existem muitos emprestimos ativos.");
            }

            var reservasDoUsuario = livro.Reservas.FindAll(reserva => reserva.codigoUsuario == codigoUsuario);
            
            if(!reservasDoUsuario && exemplares.Length <= livro.Reservas.Length)
            {
                return (false, "Emprestimo negado! Todos os Exemplares já estão reservados!");
            }          

            return (true, "Tudo OK!");
        }
    }
}
