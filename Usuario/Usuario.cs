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

        public string Emprestar(Livro livro, List<Exemplar> exemplares)
        {
            var reservasDoLivro = Reservas.FindAll(reserva => reserva.CodigoLivro == livro.Codigo);
            var emprestimosDoLivro = Emprestimos.FindAll(emprestimo => emprestimo.CodigoLivro == livro.Codigo);

            if(emprestimosDoLivro.Length > 1)
            {
                return 'Emprestimo negado! Já existe um empréstimo desse livro.';
            }
            var (podePegarEmprestimo, motivo) = this.PodePegarEmprestimo(livro, exemplar);
            if(!podePegarEmprestimo)
            {
                return motivo;
            }



            foreach (var emprestimo in Emprestimos)
            {
                int comparacao = DateTime.Compare(emprestimo.DevolucaoData, DateTime.now);

                if(comparacao < 0)
                {
                    return 'Emprestimo negado! Existem emprestimos não entregues.'
                }
            }

            if(reservasDoLivro.Length > 0)
            {
                Reservas.Remove(reservasDoLivro[0]);
            }

            DateTime devolucaoData = this.CalcularDataDevolucao();
            Emprestimo emprestimo = new Emprestimo(livro.Codigo, Codigo, devolucaoData)
            Emprestimos.Add(emprestimo);
            return 'Emprestimo realizado com sucesso'            
            
        }

        public abstract string Emprestar();
        public abstract string Reservar();
        public abstract string Devolver();
        private abstract DateTime CalcularDataDevolucao();
        private abstract Tuple<bool, string> PodePegarEmprestimo(Livro livro, List<Exemplar> exemplar);
    }
}
