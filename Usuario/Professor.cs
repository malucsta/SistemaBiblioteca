using SistemaBiblioteca.Livro;

namespace SistemaBiblioteca.Usuario
{
    public class Professor : UsuarioObservador
    {
        public Professor(int codigo, string nome) : base(codigo, nome) { }

        public override string Emprestar(Livro livro)
        {
            string baseMotivo = "Reserva não pode ser realizada. Motivo:  ";

            //se existem exemplares disponiveis
            if (!livro.PodeSerEmprestado())
                return baseMotivo + "Não há mais exemplares disponíveis";

            // se não tem emprestimos atrasados
            if (Emprestimos.Any(emprestimo => emprestimo.DevolucaoData < DateTime.Now))
                return baseMotivo + $"Existem empréstimos atrasados para o usuário {Codigo}";

            var exemplarDisponivel = livro.Exemplares.Find(exemplar => exemplar.CodigoLivro == livro.Codigo
                                                                       && exemplar.Status == EmprestimoStatus.Disponivel);

            if (exemplarDisponivel is null) return baseMotivo + "Não há mais exemplares disponíveis";

            var emprestimo = new Emprestimo(livro.Codigo, exemplarDisponivel.CodigoExemplar, this.Codigo);

            livro.Emprestimos.Add(emprestimo);
            this.Emprestimos.Add(emprestimo);
            return "Empréstimo realizado com sucesso";
        }

        public override void Notificar()
        {
            NotificacoesRecebidas++;
            Console.WriteLine($"Professor(a) {Nome} tem {NotificacoesRecebidas} notificações");
        }

        public void ObservarLivro(Livro livro)
        {
            LivrosObservados.Add(livro);
        }
    }
}
