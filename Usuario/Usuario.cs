using SistemaBiblioteca.Livro;

namespace SistemaBiblioteca.Usuario
{
    public abstract class Usuario
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public List<Reserva> Reservas { get; set; } = new List<Reserva>();
        public List<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();

        public Usuario(int codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;
        }

        public abstract string Emprestar(Livro livro);
        public string Reservar(Livro livro)
        {
            if (Reservas.Count < 3)
            {
                var reserva = new Reserva(livro.Codigo, Codigo);
                livro.Reservas.Add(reserva);
                Reservas.Add(reserva);
                return "Reserva realizada com sucesso";
            }

            return "O usuário já possui 3 ou mais reservas";
        }
        public string Devolver(ref Exemplar exemplar)
        {
            var codigoExemplar = exemplar.CodigoExemplar;
            var emprestimo = Emprestimos.Find(emprestimo => emprestimo.CodigoExemplar == codigoExemplar);

            if (emprestimo is null)
                return "Não existem empréstimos em aberto para o exemplar a ser devolvido";

            Emprestimos.Remove(emprestimo);
            // TODO: remover o empréstimo da lista de empréstimos do livro
            // TODO: alterar o status do exemplar para disponível

            exemplar.Status = EmprestimoStatus.Disponivel;
            return $"Exemplar {exemplar.CodigoExemplar} devolvido com sucesso";

        }
        public bool ExisteReservaEmAberto(int codigoLivro)
        {
            var reservasEmAberto = Reservas.FindAll(reserva => reserva.CodigoLivro == codigoLivro);
            return reservasEmAberto.Count > 0 ? true : false;
        }

        protected string? EmprestarLivro(Livro livro)
        {

            var exemplarDisponivel = livro.Exemplares.Find(exemplar => exemplar.CodigoLivro == livro.Codigo
                                                                       && exemplar.Status == EmprestimoStatus.Disponivel);

            if (exemplarDisponivel is null) return null;

            var emprestimo = new Emprestimo(livro.Codigo, exemplarDisponivel.CodigoExemplar, this.Codigo);

            //adiciona o registro dos emprestimos
            livro.Emprestimos.Add(emprestimo);
            this.Emprestimos.Add(emprestimo);

            //remove as reservas em aberto
            var reservaEmAberto = livro.Reservas.Find(reserva => reserva.CodigoLivro == livro.Codigo && reserva.CodigoUsuario == Codigo);
            if (reservaEmAberto is not null)
            {
                livro.Reservas.Remove(reservaEmAberto);
                var reservaDoUsuario = Reservas.Find(reserva => reserva.CodigoLivro == livro.Codigo);
                if (reservaDoUsuario is not null) Reservas.Remove(reservaDoUsuario);
            }

            //atualiza o status dos exemplares
            livro.Exemplares.Remove(exemplarDisponivel);
            exemplarDisponivel.Status = EmprestimoStatus.Indisponivel;
            livro.Exemplares.Add(exemplarDisponivel);

            return "Empréstimo realizado com sucesso";
        }
    }
}
