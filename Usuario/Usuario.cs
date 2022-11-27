namespace SistemaBiblioteca.Usuario
{
    public abstract class Usuario
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public List<Reserva> Reservas { get; set; }
        public List<Emprestimo> Emprestimos { get; set; }

        public Usuario(int codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;
        }

        public Tuple<bool, string, Emprestimo> Emprestar(Livro livro, List<Exemplar> exemplares)
        {
            var reservasDoLivro = Reservas.FindAll(reserva => reserva.CodigoLivro == livro.Codigo);
            var emprestimosDoLivro = Emprestimos.FindAll(emprestimo => emprestimo.CodigoLivro == livro.Codigo);
            (Exemplar exemplar) = exemplares; 

            if(emprestimosDoLivro.Length > 1)
            {
                return (false, $"Emprestimo negado para o usuario ${Nome}! Já existe um empréstimo para o livro {livro.Nome}.");
            }
            var (podePegarEmprestimo, motivo) = this.PodePegarEmprestimo(livro, exemplares);
            if(!podePegarEmprestimo)
            {
                return (false, motivo);
            }



            foreach (var emprestimo in Emprestimos)
            {
                int comparacao = DateTime.Compare(emprestimo.DevolucaoData, DateTime.now);

                if(comparacao < 0)
                {
                    return (false, $"Emprestimo do livro {livro.Nome} negado para o usuario ${Nome}! Existem emprestimos não entregues.");
                }
            }

            if(reservasDoLivro.Length > 0)
            {
                Reservas.Remove(reservasDoLivro[0]);
            }

            DateTime devolucaoData = this.CalcularDataDevolucao();
            Emprestimo emprestimo = new Emprestimo(livro.Codigo, exemplar.CodigoExemplar, Codigo, devolucaoData)
            Emprestimos.Add(emprestimo);
            return (true, $"Emprestimo do livro {livro.Nome} realizado com sucesso para o usuario ${Nome}!", emprestimo);      
            
        }

        public Tuple<bool, string, Emprestimo> Devolver(Livro livro)
        {
            var emprestimos = Emprestimos.FindAll(emprestimo => emprestimo.CodigoLivro == livro.Codigo && emprestimo.Status == "ativo");
            if(emprestimos.Length < 1)
            {
                return (false, $"Devolução negada para o usuario ${Nome}! Não exitem empréstimos ativos para o livro {livro.Nome}");
            }

            (Emprestimo emprestimoAtual) = emprestimos;
            Emprestimos.Remove(emprestimoAtual);
            emprestimoAtual.Status = "inativo";
            Emprestimos.Add(emprestimoAtual);
            return (true, $"Devolução realizada para o usuario ${Nome}! O livro {livro.Nome} foi devolvido!", emprestimoAtual);
        }

        public abstract string Reservar();
        private abstract DateTime CalcularDataDevolucao();
        private abstract Tuple<bool, string> PodePegarEmprestimo(Livro livro, List<Exemplar> exemplar);
    }
}
